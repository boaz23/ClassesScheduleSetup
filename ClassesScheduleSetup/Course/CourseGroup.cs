using System;
using System.Collections.Generic;

using static System.Linq.Enumerable;

namespace ClassesScheduleSetup
{
    public class CourseGroup
    {
        public CourseGroup(IClassActivity lecture, IEnumerable<IClassActivity> practicalClasses, IEnumerable<IClassActivity> labs)
        {
            if (lecture is null)
            {
                throw new ArgumentNullException(nameof(lecture));
            }
            if (practicalClasses is null)
            {
                throw new ArgumentNullException(nameof(practicalClasses));
            }
            if (labs is null)
            {
                throw new ArgumentNullException(nameof(labs));
            }

            Lecture = lecture;
            PracticalClasses = practicalClasses;
            Labs = labs;
        }

        public int Id => Lecture.ActivityId;
        public IClassActivity Lecture { get; }
        public IEnumerable<IClassActivity> PracticalClasses { get; }
        public IEnumerable<IClassActivity> Labs { get; }

        public override string ToString()
        {
            return Id.ToString(System.Globalization.NumberFormatInfo.CurrentInfo);
        }
    }
}
