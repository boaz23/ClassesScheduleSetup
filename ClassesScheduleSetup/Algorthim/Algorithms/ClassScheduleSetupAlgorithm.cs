using System.Collections.Generic;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    // TODO: resource cleanup (e.g. enumerators)
    // TODO: add filters for the class activities (e.g. no overlaps and at least 1 hour for launch time)
    public abstract class ClassScheduleSetupAlgorithm
    {
        public ClassScheduleSetupAlgorithm()
        {
            ClassSchedules = new List<ClassSchedule>();
            CurrentScheduleBuilder = new ClassScheduleBuilder();
        }

        private List<ClassSchedule> ClassSchedules { get; }
        private ClassScheduleBuilder CurrentScheduleBuilder { get; }

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
                ClassSchedules.Add(CurrentScheduleBuilder.BuildSchedule());
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
            CalculateSetup(courses, group, groupClassAcitivitiesEnumerator, group.Lecture);
        }

        private void CalculateSetup(ImmutableListEnumerator<Course> courses, CourseGroup group, ImmutableListEnumerator<ClassActivities> classActivitiesOfKindEnumerator)
        {
            classActivitiesOfKindEnumerator = classActivitiesOfKindEnumerator.MoveNext();
            if (classActivitiesOfKindEnumerator.HasEnded)
            {
                // next course
                CurrentScheduleBuilder.BuildCoursePlacement(courses.Current, group);
                CalculateSetup(courses);
                CurrentScheduleBuilder.RemoveLastCoursePlacement();
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
            CurrentScheduleBuilder.AddClassActivity(classActivity);
            CalculateSetup(courses, group, classActivitiesOfKindEnumerator);
            CurrentScheduleBuilder.RemoveLastClassActivity();
        }

        protected abstract IEnumerable<ClassActivities> ClassActivitiesForGroup(Course course, CourseGroup group);
    }
}
