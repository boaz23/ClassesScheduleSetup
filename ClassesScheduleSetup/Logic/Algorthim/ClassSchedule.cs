using System;
using System.Collections.Generic;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    public class ClassSchedule
    {
        public ClassSchedule(IDictionary<Course, CourseSchedulePlacement> placements, int weight)
        {
            if (EnumerableExtensions.IsNullOrEmpty(placements))
            {
                throw new ArgumentException("The enumerable cannot be empty.", nameof(placements));
            }

            CoursesPlacements = placements;
            Weight = weight;
        }

        public IDictionary<Course, CourseSchedulePlacement> CoursesPlacements { get; }
        public int Weight { get; }
    }
}
