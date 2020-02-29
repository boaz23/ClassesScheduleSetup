using System.Collections.Generic;
using System.Linq;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    public abstract class ClassScheduleSetupAlgorithm
    {
        public ClassScheduleSetupAlgorithm()
        {
            Weight = 0;
            ClassSchedules = new List<ClassSchedule>();
            CurrentPlacements = new Stack<CourseSchedulePlacement>();
            CurrentCourseActivities = new Stack<IClassActivity>();
        }

        private List<ClassSchedule> ClassSchedules { get; }
        private Stack<CourseSchedulePlacement> CurrentPlacements { get; }
        private Stack<IClassActivity> CurrentCourseActivities { get; }
        private int Weight { get; set; }

        public virtual IEnumerable<ClassSchedule> CalculateSetup(Semester semester)
        {
            return CalculateSetup(semester.Courses)
                .OrderByDescending(x => x.Weight)
                .ToList();
        }

        private IEnumerable<ClassSchedule> CalculateSetup(IEnumerable<Course> courses)
        {
            var coursesEnumerator = ImmutableListEnumerator.FromEnumerable(courses);
            CalculateSetup(coursesEnumerator);
            return ClassSchedules;
        }

        private void CalculateSetup(ImmutableListEnumerator<Course> courses)
        {
            ImmutableListEnumerator<Course> nextCourse = courses.MoveNext();
            if (nextCourse.HasEnded)
            {
                ClassSchedules.Add(BuildSchedule());
                return;
            }

            CalculateSetup(courses, nextCourse.Current);
        }

        private void CalculateSetup(ImmutableListEnumerator<Course> courses, Course course)
        {
            foreach (CourseGroup group in course.Groups)
            {
                CalculateSetup(courses, group);
            }
        }

        private void CalculateSetup(ImmutableListEnumerator<Course> courses, CourseGroup group)
        {
            IEnumerable<ClassActivities> groupClassActivities = ClassActivitiesForGroup(courses.Current, group);
            var groupClassAcitivitiesEnumerator = ImmutableListEnumerator.FromEnumerable(groupClassActivities);
            CalculateSetup(courses, group, groupClassAcitivitiesEnumerator);
        }

        private void CalculateSetup(ImmutableListEnumerator<Course> courses, CourseGroup group, ImmutableListEnumerator<ClassActivities> classActivitiesOfKindEnumerator)
        {
            ImmutableListEnumerator<ClassActivities> nextClassActivitiesOfKind = classActivitiesOfKindEnumerator.MoveNext();
            if (nextClassActivitiesOfKind.HasEnded)
            {
                if (CurrentPlacements.Count == 0 || CurrentPlacements.Peek().Course != courses.Current)
                {
                    throw new InvalidScheduleException();
                }

                // next course
                CurrentPlacements.Push(BuildCoursePlacement(courses.Current, group));
                CalculateSetup(courses);
                CurrentPlacements.Pop();
                return;
            }

            ClassActivities classActivitiesOfKind = classActivitiesOfKindEnumerator.Current;
            if (classActivitiesOfKind.IsEmpty())
            {
                if (!classActivitiesOfKind.CanBeEmpty)
                {
                    throw new InvalidScheduleException();
                }

                // next kind of activities in the same group
                CurrentCourseActivities.Push(null);
                CalculateSetup(courses, group, classActivitiesOfKindEnumerator);
            }

            foreach (IClassActivity classActivity in classActivitiesOfKind)
            {
                CurrentCourseActivities.Push(classActivity);
                Weight += classActivity.Weight;
                CalculateSetup(courses, group, classActivitiesOfKindEnumerator);
            }
        }

        protected abstract IEnumerable<ClassActivities> ClassActivitiesForGroup(Course course, CourseGroup group);

        private ClassSchedule BuildSchedule()
        {
            var schedule = new ClassSchedule(BuildScheduleMap(), Weight);
            CurrentPlacements.Clear();
            return schedule;
        }

        private IDictionary<Course, CourseSchedulePlacement> BuildScheduleMap()
        {
            return CurrentPlacements.ToDictionary(x => x.Course);
        }

        private CourseSchedulePlacement BuildCoursePlacement(Course course, CourseGroup group)
        {
            IClassActivity lab = CurrentCourseActivities.Pop();
            IClassActivity practiceClass = CurrentCourseActivities.Pop();
            Weight -= lab.Weight + practiceClass.Weight;
            return new CourseSchedulePlacement
            {
                Course = course,
                Lecture = group.Lecture,
                PracticeClass = practiceClass,
                Lab = lab,
            };
        }
    }
}
