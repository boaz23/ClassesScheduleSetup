using System;
using System.Collections;
using System.Collections.Generic;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    public class ClassActivities : IEnumerable<IClassActivity>
    {
        internal ClassActivities(IEnumerable<IClassActivity> classActivities, bool canBeEmpty)
        {
            if (classActivities is null)
            {
                throw new ArgumentNullException(nameof(classActivities));
            }
            if (!canBeEmpty && classActivities.IsEmpty())
            {
                throw new ArgumentException("There has to be at least one class activity.", nameof(InnerClassActivities));
            }

            InnerClassActivities = classActivities;
            CanBeEmpty = canBeEmpty;
        }

        public IEnumerable<IClassActivity> InnerClassActivities { get; }
        public bool CanBeEmpty { get; }

        public IEnumerator<IClassActivity> GetEnumerator() => InnerClassActivities.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => InnerClassActivities.GetEnumerator();
    }
}
