using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesScheduleSetup
{
    internal class ClassAcitivity : IClassActivity
    {
        internal ClassAcitivity(int activityId, ClassTime time)
        {
            if (activityId <= 0)
            {
                throw new ArgumentException("The activity id must be positive.", nameof(activityId));
            }

            ActivityId = activityId;
            Time = time;
        }

        public int ActivityId { get; }
        public CourseGroup Group { get; internal set; }
        public ClassTime Time { get; }
    }
}
