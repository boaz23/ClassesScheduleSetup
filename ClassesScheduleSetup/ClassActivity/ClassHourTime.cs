using System;

namespace ClassesScheduleSetup
{
    public struct ClassHourTime : IComparable<ClassHourTime>, IEquatable<ClassHourTime>
    {
        internal byte time;

        private ClassHourTime(byte time)
        {
            this.time = time;
        }

        public int Hour => time / 10;
        public int Minutes => (time % 10) * 6;

        public static ClassHourTime FromTime(byte time)
        {
            if (time >= 240)
            {
                throw new ArgumentOutOfRangeException(nameof(time), $"{nameof(time)} must be a number in [0, 239].");
            }

            return new ClassHourTime(time);
        }

        public static ClassHourTime FromParts(byte hours, bool isHalf)
        {
            if (hours >= 24)
            {
                throw new ArgumentOutOfRangeException(nameof(hours), $"{nameof(hours)} must be a number in [0, 23].");
            }

            return new ClassHourTime((byte)(10 * hours + 5 * Convert.ToInt32(isHalf)));
        }

        internal static ClassHourTime FromTime(int time)
        {
            if (time < 0 || time >= 240)
            {
                throw new ArgumentOutOfRangeException("The time must be a number in [0, 239].");
            }

            return new ClassHourTime((byte)time);
        }

        public static ClassTimeSpan operator -(ClassHourTime x, ClassHourTime y)
        {
            return new ClassTimeSpan((short)(x.time - y.time));
        }

        public static ClassHourTime operator -(ClassHourTime hour, ClassTimeSpan time)
        {
            return FromTime(hour.time - time.time);
        }

        public static ClassHourTime operator +(ClassHourTime hour, ClassTimeSpan time)
        {
            return FromTime(hour.time + time.time);
        }

        public static bool operator ==(ClassHourTime x, ClassHourTime y)
        {
            return x.time == y.time;
        }

        public static bool operator !=(ClassHourTime x, ClassHourTime y)
        {
            return x.time != y.time;
        }

        public static bool operator <(ClassHourTime x, ClassHourTime y)
        {
            return x.time < y.time;
        }

        public static bool operator <=(ClassHourTime x, ClassHourTime y)
        {
            return x.time <= y.time;
        }

        public static bool operator >(ClassHourTime x, ClassHourTime y)
        {
            return x.time > y.time;
        }

        public static bool operator >=(ClassHourTime x, ClassHourTime y)
        {
            return x.time >= y.time;
        }

        public static bool Equals(ClassHourTime x, ClassHourTime y)
        {
            return x.time == y.time;
        }

        public override bool Equals(object obj)
        {
            if (obj is ClassHourTime other)
            {
                return time == other.time;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return time.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Hour:D2}:{Minutes:D2}";
        }

        public int CompareTo(ClassHourTime other)
        {
            return time.CompareTo(other.time);
        }

        public bool Equals(ClassHourTime other)
        {
            return time == other.time;
        }

        public static ClassHourTime Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("The input string cannot be null or empty.", nameof(s));
            }

            if (s.Length != 5)
            {
                throw BadParseFormatException();
            }

            int colonIndex = s.IndexOf(':');
            if (colonIndex != 2)
            {
                throw BadParseFormatException();
            }

            int hours, minutes;
            if (!int.TryParse(s.Substring(0, colonIndex), out hours) ||
                !int.TryParse(s.Substring(colonIndex + 1), out minutes))
            {
                throw BadParseFormatException();
            }

            if (hours < 0 || hours > 23)
            {
                throw new ArgumentOutOfRangeException("The hours must be a number in [0, 23].");
            }
            if (minutes < 0 || minutes > 59)
            {
                throw new ArgumentOutOfRangeException("The minutes must be a number in [0, 59].");
            }

            return FromTime(10 * hours + minutes / 6);
        }

        private static FormatException BadParseFormatException()
        {
            return new FormatException(@"The string format should be '\d\d:\d\d'");
        }
    }
}