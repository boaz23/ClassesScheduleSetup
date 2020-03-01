using System;
using System.Collections.Generic;
using Utility.Linq;

namespace ClassesScheduleSetup
{
    public class NoOverlapsAndLaunchTimeClassActivityCollection : ClassActivityCollection
    {
        public NoOverlapsAndLaunchTimeClassActivityCollection()
        {
            ScheduleTimes = new ClassTimesCollection();
        }

        protected ClassTimesCollection ScheduleTimes { get; }

        public override bool Add(IClassActivity classActivity)
        {
            if (classActivity != null)
            {
                if (!ScheduleTimes.AddAlIfNoneOverlap(classActivity.Times))
                {
                    return false;
                }

                if (!HasLaunchBreak())
                {
                    ScheduleTimes.RemoveAll(classActivity.Times);
                    return false;
                }
            }

            return base.Add(classActivity);
        }

        public override IClassActivity RemoveLast()
        {
            IClassActivity classActivity = base.RemoveLast();
            if (classActivity != null)
            {
                ScheduleTimes.RemoveAll(classActivity.Times);
            }

            return classActivity;
        }

        private bool HasLaunchBreak()
        {
            for (DayOfWeek day = DayOfWeek.Sunday; day <= DayOfWeek.Saturday; day++)
            {
                var launchTime = new ClassTime(day, ClassHourTime.FromParts(12, false), ClassHourTime.FromParts(15, false));
                IEnumerable<ClassTime> intersection = ScheduleTimes.IntersectWith(launchTime);
                if (intersection.IsEmpty())
                {
                    continue;
                }

                ClassHourTime prevEnd = launchTime.Start;
                ClassHourTime currentStart;
                bool validDay = false;
                foreach (ClassTime classTime in intersection)
                {
                    currentStart = classTime.Start;
                    if (HasAtLeastOneHourSpace(prevEnd, currentStart))
                    {
                        validDay = true;
                        break;
                    }

                    prevEnd = classTime.End;
                }

                if (!validDay)
                {
                    currentStart = launchTime.End;
                    if (HasAtLeastOneHourSpace(prevEnd, currentStart))
                    {
                        validDay = true;
                    }
                }
                if (!validDay)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasAtLeastOneHourSpace(ClassHourTime prevEnd, ClassHourTime currentStart)
        {
            ClassTimeSpan diff = currentStart - prevEnd;
            return diff.TotalHours >= 1;
        }
    }
}
