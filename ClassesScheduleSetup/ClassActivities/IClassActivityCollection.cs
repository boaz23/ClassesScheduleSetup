namespace ClassesScheduleSetup
{
    public interface IClassActivityCollection
    {
        int TotalWeight { get; }

        bool Add(IClassActivity classActivity);
        void RemoveLast();
        CourseSchedulePlacement BuildCoursePlacement(Course course, CourseGroup group);
    }
}
