using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace ClassesScheduleSetup
{
    internal class ClassActivityBuilder
    {
        public ClassActivityBuilder()
        {
            Weight = ClassWeights.Normal;
            ClassTimes = new List<ClassTimeBuilder>();
        }
        public ClassActivityBuilder(int activityId) : this()
        {
            ActivityId = activityId;
        }

        public int ActivityId { get; set; }
        public ClassWeights Weight { get; set; }
        public ClassTimeBuilder ClassTime { get; set; }
        public ICollection<ClassTimeBuilder> ClassTimes { get; }

        internal ClassAcitivity CreateClassActivity()
        {
            if (ClassTime == null && ClassTimes.Count == 0)
            {
                throw new InvalidOperationException("No time has been set.");
            }

            return new ClassAcitivity(
                ActivityId,
                (int)Weight,
                GetClassTimes()
            );
        }

        private IEnumerable<ClassTime> GetClassTimes()
        {
            IEnumerable<ClassTime> times;
            if (ClassTime == null)
            {
                times = BuildClassTimes(ClassTimes);
            }
            else
            {
                times = new ClassTime[]
                {
                    ClassTime.CreateClassTime()
                };
            }

            return times;
        }

        private static IEnumerable<ClassTime> BuildClassTimes(IEnumerable<ClassTimeBuilder> classTimes)
        {
            return classTimes
                .Select(t => t.CreateClassTime())
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

        internal ClassTime CreateClassTime()
        {
            return new ClassTime(
                Day,
                ClassHourTime.Parse(Start),
                ClassHourTime.Parse(End)
            );
        }
    }
}
