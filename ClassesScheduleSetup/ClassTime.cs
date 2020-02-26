using System;
using System.Globalization;

namespace ClassesScheduleSetup
{
    internal struct ClassTime : IEquatable<ClassTime>
    {
        internal DayOfWeek day;
        internal ClassHourTime start;
        internal ClassHourTime end;

        public ClassTime(DayOfWeek day, ClassHourTime start, ClassHourTime end)
        {
            this.start = start;
            this.end = end;
            this.day = day;
        }

        public static bool operator ==(ClassTime x, ClassTime y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(ClassTime x, ClassTime y)
        {
            return !Equals(x, y);
        }

        public static bool Equals(ClassTime x, ClassTime y)
        {
            return x.day == y.day &&
                   x.start == y.start &&
                   x.end == y.end;
        }

        public override bool Equals(object obj)
        {
            if (obj is ClassHourTime other)
            {
                return Equals(this, other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string dayName = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[(int)day];
            return $"{dayName} {start}-{end}";
        }

        public bool Equals(ClassTime other)
        {
            return Equals(this, other);
        }
    }
}
