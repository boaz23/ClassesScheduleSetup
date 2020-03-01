using System;
using System.Collections.Generic;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    public class ClassSchedule
    {
        public ClassSchedule(IDictionary<Course, CourseSchedulePlacement> placements, int weight, int permutationIndex)
        {
            if (EnumerableExtensions.IsNullOrEmpty(placements))
            {
                throw new ArgumentException("The enumerable cannot be empty.", nameof(placements));
            }

            CoursesPlacements = placements;
            Weight = weight;
            PermutationIndex = permutationIndex;
        }

        public IDictionary<Course, CourseSchedulePlacement> CoursesPlacements { get; }
        public int Weight { get; }
        public int PermutationIndex { get; }
    }
}
