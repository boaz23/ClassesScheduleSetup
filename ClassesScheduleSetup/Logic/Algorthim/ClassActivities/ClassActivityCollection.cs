using System.Collections.Generic;

using ClassesScheduleSetup.ClassActivity;

using Utility.Collections.Generic;

namespace ClassesScheduleSetup
{
    public class ClassActivityCollection : IClassActivityCollection
    {
        public ClassActivityCollection()
        {
            TotalWeight = 0;
            CurrentCourseActivities = new List<IClassActivity>();
        }

        public virtual int TotalWeight { get; protected set; }
        protected List<IClassActivity> CurrentCourseActivities { get; }

        public virtual bool Add(IClassActivity classActivity)
        {
            CurrentCourseActivities.Add(classActivity);
            TotalWeight += classActivity.Weight();
            return true;
        }

        public virtual IClassActivity RemoveLast()
        {
            IClassActivity classActivity = CurrentCourseActivities.RemoveLast();
            TotalWeight -= classActivity.Weight();
            return classActivity;
        }

        public virtual CourseSchedulePlacement BuildCoursePlacement(Course course, CourseGroup group)
        {
            IClassActivity lab = CurrentCourseActivities[^1];
            IClassActivity practiceClass = CurrentCourseActivities[^2];
            IClassActivity lecture = CurrentCourseActivities[^3];
            return new CourseSchedulePlacement
            {
                Course = course,
                Lecture = lecture,
                PracticeClass = practiceClass,
                Lab = lab,
            };
        }
    }
}
