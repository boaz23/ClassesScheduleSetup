using System.Collections.Generic;
using System.Linq;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    internal class PracticeClassFromAllGroupsSetupAlgorithm : ClassScheduleSetupAlgorithm
    {
        public PracticeClassFromAllGroupsSetupAlgorithm(IClassActivityCollection classActivitiesCollection) : base(classActivitiesCollection)
        {
            PraticeClasses = new Dictionary<Course, ClassActivitiesInfo>();
        }

        private IDictionary<Course, ClassActivitiesInfo> PraticeClasses { get; }

        public override IEnumerable<ClassSchedule> CalculateSetup(Semester semester)
        {
            BuildPraticeClasses(semester.Courses);
            return base.CalculateSetup(semester);
        }

        protected override IEnumerable<ClassActivitiesInfo> ClassActivitiesForGroup(Course course, CourseGroup group)
        {
            return EnumerableExtensions.AsEnumerable
            (
                PraticeClasses[course],
                new ClassActivitiesInfo(group.Labs, true)
            );
        }

        private void BuildPraticeClasses(IEnumerable<Course> courses)
        {
            PraticeClasses.Clear();
            foreach (Course course in courses)
            {
                BuildPraticeClassesForCourse(course);
            }
        }

        private void BuildPraticeClassesForCourse(Course course)
        {
            PraticeClasses[course] = new ClassActivitiesInfo(GetAllPracticeClassesOfCourse(course), true);
        }

        private static IEnumerable<IClassActivity> GetAllPracticeClassesOfCourse(Course course)
        {
            return course.Groups.SelectMany(group => group.PracticalClasses);
        }
    }
}
