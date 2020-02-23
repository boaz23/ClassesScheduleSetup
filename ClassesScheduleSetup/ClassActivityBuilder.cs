using System;

namespace ClassesScheduleSetup
{
    internal class ClassActivityBuilder
    {
        public ClassActivityBuilder() { }
        public ClassActivityBuilder(int activityId, DayOfWeek day, string start, string end)
        {
            ActivityId = activityId;
            Day = day;
            Start = start;
            End = end;
        }

        public int ActivityId { get; set; }
        public DayOfWeek Day { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        internal ClassAcitivity CreateClassActivity()
        {
            return new ClassAcitivity(
                ActivityId,
                new ClassTime(
                    Day,
                    ClassHourTime.Parse(Start),
                    ClassHourTime.Parse(End)
                )
            );
        }
    }
}
