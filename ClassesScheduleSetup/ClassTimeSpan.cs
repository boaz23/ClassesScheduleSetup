using System;

namespace ClassesScheduleSetup
{
    internal struct ClassTimeSpan : IComparable<ClassHourTime>, IEquatable<ClassHourTime>
    {
        internal short time;

        public ClassTimeSpan(short time)
        {
            this.time = time;
        }

        public ClassTimeSpan Duration()
        {
            return new ClassTimeSpan(Math.Abs(time));
        }

        internal static ClassTimeSpan FromTime(int time)
        {
            return new ClassTimeSpan((short)time);
        }

        public static ClassTimeSpan operator -(ClassTimeSpan x, ClassTimeSpan y)
        {
            return FromTime(x.time - y.time);
        }

        public static ClassTimeSpan operator +(ClassTimeSpan x, ClassTimeSpan y)
        {
            return FromTime(x.time + y.time);
        }

        public static bool operator ==(ClassTimeSpan x, ClassTimeSpan y)
        {
            return x.time == y.time;
        }

        public static bool operator !=(ClassTimeSpan x, ClassTimeSpan y)
        {
            return x.time != y.time;
        }

        public static bool operator <(ClassTimeSpan x, ClassTimeSpan y)
        {
            return x.time < y.time;
        }

        public static bool operator <=(ClassTimeSpan x, ClassTimeSpan y)
        {
            return x.time <= y.time;
        }

        public static bool operator >(ClassTimeSpan x, ClassTimeSpan y)
        {
            return x.time > y.time;
        }

        public static bool operator >=(ClassTimeSpan x, ClassTimeSpan y)
        {
            return x.time >= y.time;
        }

        public static bool Equals(ClassTimeSpan x, ClassTimeSpan y)
        {
            return x.time == y.time;
        }

        public override bool Equals(object obj)
        {
            if (obj is ClassTimeSpan other)
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
            return $"{time / 10}:{(time % 10) * 6}";
        }

        public int CompareTo(ClassHourTime other)
        {
            return time.CompareTo(other.time);
        }

        public bool Equals(ClassHourTime other)
        {
            return time == other.time;
        }
    }
}
