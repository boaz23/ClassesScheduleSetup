namespace ClassesScheduleSetup
{
    public class NoOverlapsClassActivityCollection : ClassActivityCollection
    {
        public NoOverlapsClassActivityCollection()
        {
            ScheduleTimes = new ClassTimesCollection();
        }

        protected ClassTimesCollection ScheduleTimes { get; }

        public override bool Add(IClassActivity classActivity)
        {
            if (!ScheduleTimes.AddAlIfNoneOverlap(classActivity.Times))
            {
                return false;
            }

            return base.Add(classActivity);
        }

        public override IClassActivity RemoveLast()
        {
            IClassActivity classActivity = base.RemoveLast();
            ScheduleTimes.RemoveAll(classActivity.Times);
            return classActivity;
        }
    }
}
