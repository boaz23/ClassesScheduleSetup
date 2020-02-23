namespace ClassesScheduleSetup
{
    internal static partial class Semesters
    {
        static Semesters()
        {
            SemesterC = SemesterC_Builder().Build();
        }

        public static Semester SemesterC { get; }
    }
}
