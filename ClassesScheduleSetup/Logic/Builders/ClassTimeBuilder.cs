using System;

namespace ClassesScheduleSetup
{
    public class ClassTimeBuilder
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
