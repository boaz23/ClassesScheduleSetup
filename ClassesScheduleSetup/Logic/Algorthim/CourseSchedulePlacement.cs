using System.Diagnostics;
using System.Text;

namespace ClassesScheduleSetup
{
    public class CourseSchedulePlacement
    {
        public Course Course { get; set; }
        public IClassActivity Lecture { get; set; }
        public IClassActivity PracticeClass { get; set; }
        public IClassActivity Lab { get; set; }

        public override string ToString()
        {
            string s = $"{Course}, {Lecture.ActivityId}";
            if (PracticeClass != null)
            {
                s += $", {PracticeClass.ActivityId}";
            }
            if (Lab != null)
            {
                s += $", {Lab.ActivityId}";
            }

            return s;
        }
    }
}
