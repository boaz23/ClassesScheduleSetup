using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesScheduleSetup
{
    internal class ClassAcitivity : IClassActivity
    {
        internal ClassAcitivity(int activityId, IEnumerable<ClassTime> times)
        {
            if (activityId <= 0)
            {
                throw new ArgumentException("The activity id must be positive.", nameof(activityId));
            }

            ActivityId = activityId;
            Times = times;
        }

        public int ActivityId { get; }
        public CourseGroup Group { get; internal set; }
        public IEnumerable<ClassTime> Times { get; }

        public override string ToString()
        {
            return $"{ActivityId}: {string.Join(", ", Times)}";
        }
    }
}
