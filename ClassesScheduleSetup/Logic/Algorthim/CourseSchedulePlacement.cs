using System.Diagnostics;

namespace ClassesScheduleSetup
{
    [DebuggerDisplay("{Course}, {Lecture.ActivityId}, {PracticeClass.ActivityId}, {Lab.ActivityId}")]
    public class CourseSchedulePlacement
    {
        public Course Course { get; set; }
        public IClassActivity Lecture { get; set; }
        public IClassActivity PracticeClass { get; set; }
        public IClassActivity Lab { get; set; }
    }
}
