using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace ClassesScheduleSetup
{
    internal class ClassActivityBuilder
    {
        public ClassActivityBuilder()
        {
            ClassTimes = new List<ClassTimeBuilder>();
        }
        public ClassActivityBuilder(int activityId) : this()
        {
            ActivityId = activityId;
        }

        public int ActivityId { get; set; }
        public ClassTimeBuilder Time { get; set; }
        public ICollection<ClassTimeBuilder> ClassTimes { get; }

        internal ClassAcitivity CreateClassActivity()
        {
            if (Time == null && ClassTimes.Count == 0)
            {
                throw new InvalidOperationException("No time has been set.");
            }

            return new ClassAcitivity(
                ActivityId,
                GetClassTimes()
            );
        }

        private IEnumerable<ClassTime> GetClassTimes()
        {
            IEnumerable<ClassTime> times;
            if (Time == null)
            {
                times = BuildClassActivities(ClassTimes);
            }
            else
            {
                times = new ClassTime[]
                {
                    Time.CreateClassActivity()
                };
            }

            return times;
        }

        private static IEnumerable<ClassTime> BuildClassActivities(IEnumerable<ClassTimeBuilder> classTimes)
        {
            return classTimes
                .Select(t => t.CreateClassActivity())
                .ToList();
        }
    }

    internal class ClassTimeBuilder
    {
        public ClassTimeBuilder() { }
        public ClassTimeBuilder(DayOfWeek day, string start, string end)
        {
            Day = day;
            Start = start;
            End = end;
        }

        public DayOfWeek Day { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        internal ClassTime CreateClassActivity()
        {
            return new ClassTime(
                Day,
                ClassHourTime.Parse(Start),
                ClassHourTime.Parse(End)
            );
        }
    }
}
