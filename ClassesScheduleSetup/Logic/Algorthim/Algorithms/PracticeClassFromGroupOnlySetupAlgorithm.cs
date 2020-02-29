using System.Collections.Generic;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    internal class PracticeClassFromGroupOnlySetupAlgorithm : ClassScheduleSetupAlgorithm
    {
        public PracticeClassFromGroupOnlySetupAlgorithm(IClassActivityCollection classActivitiesCollection) : base(classActivitiesCollection)
        {
        }

        protected override IEnumerable<ClassActivitiesInfo> ClassActivitiesForGroup(Course course, CourseGroup group)
        {
            return EnumerableExtensions.AsEnumerable
            (
                new ClassActivitiesInfo(group.PracticalClasses, false),
                new ClassActivitiesInfo(group.Labs, true)
            );
        }
    }
}
