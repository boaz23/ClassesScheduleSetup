using System.Collections.Generic;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    internal class PracticeClassFromGroupOnlySetupAlgorithm : ClassScheduleSetupAlgorithm
    {
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
