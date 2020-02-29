using System.Collections.Generic;
using System.Linq;

using ClassesScheduleSetup.ClassActivity;

using Utility.Collections.Generic;
using Utility.Linq;

namespace ClassesScheduleSetup
{
    // TODO: resource cleanup (e.g. enumerators)
    // TODO: add filters for the class activities (e.g. no overlaps and at least 1 hour for launch time)
    public abstract class ClassScheduleSetupAlgorithm
    {
        public ClassScheduleSetupAlgorithm()
        {
            Weight = 0;
            ClassSchedules = new List<ClassSchedule>();
            CurrentPlacements = new List<CourseSchedulePlacement>();
            CurrentCourseActivities = new List<IClassActivity>();
        }

        private List<ClassSchedule> ClassSchedules { get; }
        private List<CourseSchedulePlacement> CurrentPlacements { get; }
        private List<IClassActivity> CurrentCourseActivities { get; }
        private int Weight { get; set; }

        public virtual IEnumerable<ClassSchedule> CalculateSetup(Semester semester)
        {
            return CalculateSetup(semester.Courses);
        }

        private IEnumerable<ClassSchedule> CalculateSetup(IEnumerable<Course> courses)
        {
            var coursesEnumerator = ImmutableListEnumerator.FromEnumerable(courses);
            CalculateSetup(coursesEnumerator);
            return ClassSchedules;
        }

        private void CalculateSetup(ImmutableListEnumerator<Course> courses)
        {
            courses = courses.MoveNext();
            if (courses.HasEnded)
            {
                ClassSchedules.Add(BuildSchedule());
                return;
            }

            foreach (CourseGroup group in courses.Current.Groups)
            {
                CalculateSetup(courses, group);
            }
        }

        private void CalculateSetup(ImmutableListEnumerator<Course> courses, CourseGroup group)
        {
            IEnumerable<ClassActivities> groupClassActivities = ClassActivitiesForGroup(courses.Current, group);
            var groupClassAcitivitiesEnumerator = ImmutableListEnumerator.FromEnumerable(groupClassActivities);
            Weight += group.Lecture.Weight();
            CalculateSetup(courses, group, groupClassAcitivitiesEnumerator);
            Weight -= group.Lecture.Weight();
        }

        private void CalculateSetup(ImmutableListEnumerator<Course> courses, CourseGroup group, ImmutableListEnumerator<ClassActivities> classActivitiesOfKindEnumerator)
        {
            classActivitiesOfKindEnumerator = classActivitiesOfKindEnumerator.MoveNext();
            if (classActivitiesOfKindEnumerator.HasEnded)
            {
                // next course
                CurrentPlacements.Add(BuildCoursePlacement(courses.Current, group));
                CalculateSetup(courses);
                CurrentPlacements.RemoveLast();
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
                CalculateSetup(courses, group, classActivitiesOfKindEnumerator, null);
                return;
            }

            foreach (IClassActivity classActivity in classActivitiesOfKind)
            {
                CalculateSetup(courses, group, classActivitiesOfKindEnumerator, classActivity);
            }
        }

        private void CalculateSetup
        (
            ImmutableListEnumerator<Course> courses,
            CourseGroup group,
            ImmutableListEnumerator<ClassActivities> classActivitiesOfKindEnumerator,
            IClassActivity classActivity
        )
        {
            CurrentCourseActivities.Add(classActivity);
            Weight += classActivity.Weight();
            CalculateSetup(courses, group, classActivitiesOfKindEnumerator);
            Weight -= classActivity.Weight();
            CurrentCourseActivities.RemoveLast();
        }

        protected abstract IEnumerable<ClassActivities> ClassActivitiesForGroup(Course course, CourseGroup group);

        private ClassSchedule BuildSchedule()
        {
            return new ClassSchedule(BuildScheduleMap(), Weight);
        }

        private IDictionary<Course, CourseSchedulePlacement> BuildScheduleMap()
        {
            return CurrentPlacements.ToDictionary(x => x.Course);
        }

        private CourseSchedulePlacement BuildCoursePlacement(Course course, CourseGroup group)
        {
            IClassActivity lab = CurrentCourseActivities[^1];
            IClassActivity practiceClass = CurrentCourseActivities[^2];
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
