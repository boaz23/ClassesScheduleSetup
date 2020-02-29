using System.Collections.Generic;
using System.Linq;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    internal class PracticeClassFromAllGroupsSetupAlgorithm : ClassScheduleSetupAlgorithm
    {
        public PracticeClassFromAllGroupsSetupAlgorithm()
        {
            PraticeClasses = new Dictionary<Course, ClassActivities>();
        }

        private IDictionary<Course, ClassActivities> PraticeClasses { get; }

        public override IEnumerable<ClassSchedule> CalculateSetup(Semester semester)
        {
            BuildPraticeClasses(semester.Courses);
            return base.CalculateSetup(semester);
        }

        protected override IEnumerable<ClassActivities> ClassActivitiesForGroup(Course course, CourseGroup group)
        {
            return EnumerableExtensions.AsEnumerable(PraticeClasses[course], new ClassActivities(group.Labs, true));
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
            PraticeClasses[course] = new ClassActivities(GetAllPracticeClassesOfCourse(course), false);
        }

        private IEnumerable<IClassActivity> GetAllPracticeClassesOfCourse(Course course)
        {
            return course.Groups.SelectMany(group => group.PracticalClasses);
        }
    }
}
