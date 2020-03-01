using System.Collections.Generic;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    // TODO: (Decorator pattern) Permutation indecies
    // TODO: (Decorator pattern) Filters for the class activities (e.g. no overlaps and at least 1 hour for launch time)
    // TODO: (Decorator pattern) Class activities from group (practice classes from group only or from all groups)
    // TODO: Resource cleanup (e.g. enumerators)
    public abstract class ClassScheduleSetupAlgorithm
    {
        // IDEA: reference to the algorithm instance with the data to operate on (and chain it in the constructor)
        public ClassScheduleSetupAlgorithm(IClassActivityCollection classActivitiesCollection)
        {
            ClassSchedules = new List<ClassSchedule>();
            CurrentScheduleBuilder = new ClassScheduleBuilder(classActivitiesCollection);
        }

        private List<ClassSchedule> ClassSchedules { get; }
        private ClassScheduleBuilder CurrentScheduleBuilder { get; }

        protected abstract IEnumerable<ClassActivitiesInfo> ClassActivitiesForGroup(Course course, CourseGroup group);

        public virtual IEnumerable<ClassSchedule> CalculateSetup(Semester semester)
        {
            return CalculateSetup(semester.Courses);
        }

        private IEnumerable<ClassSchedule> CalculateSetup(IEnumerable<Course> courses)
        {
            var coursesEnumerator = ImmutableListEnumerator.FromEnumerable(courses);
            CalculateSetup_NextCourse(coursesEnumerator);
            return ClassSchedules;
        }

        private bool CalculateSetup_NextCourse(ImmutableListEnumerator<Course> courses)
        {
            courses = courses.MoveNext();
            if (courses.HasEnded)
            {
                return BuildSchedule();
            }

            return CalculateSetup_CourseGroups(courses);
        }

        private bool BuildSchedule()
        {
            ClassSchedules.Add(CurrentScheduleBuilder.BuildSchedule());
            return true;
        }

        private bool CalculateSetup_CourseGroups(ImmutableListEnumerator<Course> courses)
        {
            bool atLeastOne = false;
            foreach (CourseGroup group in courses.Current.Groups)
            {
                bool successs = CalculateSetup_NextGroup(courses, group);
                if (successs)
                {
                    atLeastOne = true;
                }
            }

            return atLeastOne;
        }

        private bool CalculateSetup_NextGroup(ImmutableListEnumerator<Course> courses, CourseGroup group)
        {
            IEnumerable<ClassActivitiesInfo> groupClassActivities = ClassActivitiesForGroup(courses.Current, group);
            var groupClassAcitivitiesEnumerator = ImmutableListEnumerator.FromEnumerable(groupClassActivities);
            return CalculateSetup_NextClassActivity(courses, group, groupClassAcitivitiesEnumerator, group.Lecture);
        }

        private bool CalculateSetup_NextClassActivity
        (
            ImmutableListEnumerator<Course> courses,
            CourseGroup group,
            ImmutableListEnumerator<ClassActivitiesInfo> classActivitiesOfKindEnumerator,
            IClassActivity classActivity
        )
        {
            if (!CurrentScheduleBuilder.AddClassActivity(classActivity))
            {
                return false;
            }
            CalculateSetup_NextKindOfClassActivities(courses, group, classActivitiesOfKindEnumerator);
            CurrentScheduleBuilder.RemoveLastClassActivity();
            return true;
        }

        private bool CalculateSetup_NextKindOfClassActivities
        (
            ImmutableListEnumerator<Course> courses,
            CourseGroup group,
            ImmutableListEnumerator<ClassActivitiesInfo> classActivitiesOfKindEnumerator
        )
        {
            classActivitiesOfKindEnumerator = classActivitiesOfKindEnumerator.MoveNext();
            if (classActivitiesOfKindEnumerator.HasEnded)
            {
                return CalculateSetup_BuildCoursePlacement(courses, group);
            }

            ClassActivitiesInfo classActivitiesOfKind = classActivitiesOfKindEnumerator.Current;
            if (classActivitiesOfKind.IsEmpty())
            {
                return CalculateSetup_EmptyKindOfClassActivities(courses, group, classActivitiesOfKindEnumerator, classActivitiesOfKind);
            }
            else
            {
                return CalculateSetup_ClassActivitiesOfKind(courses, group, classActivitiesOfKindEnumerator, classActivitiesOfKind);
            }
        }

        private bool CalculateSetup_BuildCoursePlacement(ImmutableListEnumerator<Course> courses, CourseGroup group)
        {
            CurrentScheduleBuilder.BuildCoursePlacement(courses.Current, group);
            bool success = CalculateSetup_NextCourse(courses);
            CurrentScheduleBuilder.RemoveLastCoursePlacement();
            return success;
        }

        private bool CalculateSetup_EmptyKindOfClassActivities
        (
            ImmutableListEnumerator<Course> courses,
            CourseGroup group,
            ImmutableListEnumerator<ClassActivitiesInfo> classActivitiesOfKindEnumerator,
            ClassActivitiesInfo classActivitiesOfKind)
        {
            if (!classActivitiesOfKind.CanBeEmpty)
            {
                throw new InvalidScheduleException("The class activities cannot be empty");
            }

            return CalculateSetup_NextClassActivity(courses, group, classActivitiesOfKindEnumerator, null);
        }

        private bool CalculateSetup_ClassActivitiesOfKind
        (
            ImmutableListEnumerator<Course> courses,
            CourseGroup group,
            ImmutableListEnumerator<ClassActivitiesInfo> classActivitiesOfKindEnumerator,
            ClassActivitiesInfo classActivitiesOfKind
        )
        {
            bool atLeastOne = false;
            foreach (IClassActivity classActivity in classActivitiesOfKind)
            {
                bool successs = CalculateSetup_NextClassActivity(courses, group, classActivitiesOfKindEnumerator, classActivity);
                if (successs)
                {
                    atLeastOne = true;
                }
            }

            return atLeastOne;
        }
    }
}
