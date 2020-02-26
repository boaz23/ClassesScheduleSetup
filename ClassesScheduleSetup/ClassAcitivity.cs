using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesScheduleSetup
{
    internal class ClassAcitivity : IClassActivity
    {
        internal ClassAcitivity(int activityId, int weight, IEnumerable<ClassTime> times)
        {
            if (activityId <= 0)
            {
                throw new ArgumentException("The activity id must be positive.", nameof(activityId));
            }

            ActivityId = activityId;
            Weight = weight;
            Times = times;
        }

        public int ActivityId { get; }
        public int Weight { get; }
        public CourseGroup Group { get; internal set; }
        public IEnumerable<ClassTime> Times { get; }

        public override string ToString()
        {
            string s = $"{ActivityId}: {string.Join(", ", Times)}";
            if (Weight != 0)
            {
                s += $", Weight={Weight}";
            }

            return s;
        }
    }
}
