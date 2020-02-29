using System.Collections.Generic;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    internal class PracticeClassFromGroupOnlySetupAlgorithm : ClassScheduleSetupAlgorithm
    {
        public PracticeClassFromGroupOnlySetupAlgorithm(IClassActivitiesCollection classActivitiesCollection) : base(classActivitiesCollection)
        {
        }

        protected override IEnumerable<ClassActivities> ClassActivitiesForGroup(Course course, CourseGroup group)
        {
            return EnumerableExtensions.AsEnumerable
            (
                new ClassActivities(group.PracticalClasses, false),
                new ClassActivities(group.Labs, true)
            );
        }
    }
}
