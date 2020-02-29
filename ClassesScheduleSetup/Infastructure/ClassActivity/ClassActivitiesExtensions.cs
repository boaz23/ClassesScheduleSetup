namespace ClassesScheduleSetup.ClassActivity
{
    public static class ClassActivitiesExtensions
    {
        public static int Weight(this IClassActivity classActivity)
        {
            return classActivity?.Weight ?? 0;
        }
    }
}
