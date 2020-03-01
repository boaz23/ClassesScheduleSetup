using System;

namespace ClassesScheduleSetup
{
    public struct ClassTimeSpan : IComparable<ClassTimeSpan>, IEquatable<ClassTimeSpan>
    {
        internal short time;

        public ClassTimeSpan(short time)
        {
            this.time = time;
        }

        public decimal TotalHours
        {
            get
            {
                return time / 10m;
            }
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

        public int CompareTo(ClassTimeSpan other)
        {
            return time.CompareTo(other.time);
        }

        public bool Equals(ClassTimeSpan other)
        {
            return time == other.time;
        }
    }
}
