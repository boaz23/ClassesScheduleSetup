﻿using System;
using System.Collections.Generic;
using System.Globalization;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    // TODO: refactor to use an interval class
    public struct ClassTime : IEquatable<ClassTime>
    {
        internal DayOfWeek day;
        internal ClassHourTime start;
        internal ClassHourTime end;

        public ClassTime(DayOfWeek day, ClassHourTime start, ClassHourTime end)
        {
            if (start > end)
            {
                throw new ArgumentException("start must be less than or equal to end.");
            }

            this.start = start;
            this.end = end;
            this.day = day;
        }

        public DayOfWeek Day => day;
        public ClassHourTime Start => start;
        public ClassHourTime End => end;

        public ClassTime? IntersectWith(ClassTime other)
        {
            if (!Overlaps(other))
            {
                return null;
            }

            return new ClassTime(day, ClassHourTime.Max(start, other.start), ClassHourTime.Min(end, other.end));
        }

        public bool Overlaps(ClassTime other)
        {
            return day == other.day &&
                   start < other.end &&
                   other.start < end;
        }

        public bool OverlapsOrContinousWith(ClassTime other) {
            return day == other.day &&
                   start <= other.end &&
                   other.start <= end;
        }

        public bool IsContinuousWith(ClassTime other)
        {
            return day == other.day && (end == other.start || other.start == end);
        }

        public ClassTime? UnionIfOverlapsOrContinousWith(ClassTime other)
        {
            if (OverlapsOrContinousWith(other))
            {
                var start = ClassHourTime.Min(this.start, other.start);
                var end = ClassHourTime.Max(this.end, other.end);
                return new ClassTime(day, start, end);
            }

            return null;
        }

        public IEnumerable<ClassTime> Subtract(ClassTime other)
        {
            if (!Overlaps(other))
            {
                return EnumerableExtensions.AsEnumerable(this);
            }

            var result = new List<ClassTime>(2);
            if (Contains(other.start))
            {
                result.Add(new ClassTime(day, start, other.start));
            }
            if (Contains(other.end))
            {
                result.Add(new ClassTime(day, other.end, end));
            }

            return result;
        }

        public bool Contains(ClassHourTime hour)
        {
            return start < hour && hour < end;
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
