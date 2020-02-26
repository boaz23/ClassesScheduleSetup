using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassesScheduleSetup
{
    internal class ClassSchedule
    {
        public ClassSchedule(ILookup<Course, CourseSchedulePlacement> placements, int weight)
        {
            if (EnumerableExtensions.IsNullOrEmpty(placements))
            {
                throw new ArgumentException("The enumerable cannot be empty.", nameof(placements));
            }

            CoursesPlacements = placements;
            Weight = weight;
        }

        public ILookup<Course, CourseSchedulePlacement> CoursesPlacements { get; }
        public int Weight { get; }
    }
}
