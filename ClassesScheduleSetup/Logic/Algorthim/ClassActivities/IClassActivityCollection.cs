namespace ClassesScheduleSetup
{
    public interface IClassActivityCollection
    {
        int TotalWeight { get; }

        bool Add(IClassActivity classActivity);
        IClassActivity RemoveLast();
        CourseSchedulePlacement BuildCoursePlacement(Course course, CourseGroup group);
    }
}
