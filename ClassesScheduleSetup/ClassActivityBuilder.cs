using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    internal class ClassActivityBuilder
    {
        public ClassActivityBuilder()
        {
            Weight = ClassWeights.Normal;
            ClassTimes = new List<ClassTimeBuilder>();
            ClassTimes_Concreate = new List<ClassTime>();
        }
        public ClassActivityBuilder(int activityId) : this()
        {
            ActivityId = activityId;
        }

        public int ActivityId { get; set; }
        public ClassWeights Weight { get; set; }
        public ClassTimeBuilder ClassTime { get; set; }
        public ICollection<ClassTimeBuilder> ClassTimes { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ICollection<ClassTime> ClassTimes_Concreate { get; }

        public void ClearAllTimes()
        {
            ClassTime = null;
            ClassTimes.Clear();
            ClassTimes_Concreate.Clear();
        }

        internal ClassAcitivity CreateClassActivity()
        {
            IEnumerable<ClassTime> classTimes = GetClassTimes();
            if (classTimes == null)
            {
                throw new InvalidOperationException("No time has been set.");
            }

            return new ClassAcitivity
            (
                ActivityId,
                (int)Weight,
                classTimes
            );
        }

        internal IEnumerable<ClassTime> GetClassTimes()
        {
            IEnumerable<ClassTime> times = null;
            if (ClassTimes_Concreate.Any())
            {
                times = ClassTimes_Concreate.ToList();
            }
            else if (ClassTime != null)
            {
                times = EnumerableExtensions.AsEnumerable(ClassTime.CreateClassTime())
                    .ToList();
            }
            else if (ClassTimes.Any())
            {
                times = BuildClassTimes(ClassTimes);
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
