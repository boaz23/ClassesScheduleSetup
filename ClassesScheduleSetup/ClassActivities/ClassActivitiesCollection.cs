using System.Collections.Generic;

using ClassesScheduleSetup.ClassActivity;

using Utility.Collections.Generic;

namespace ClassesScheduleSetup
{
    public class ClassActivitiesCollection : IClassActivityCollection
    {
        public ClassActivitiesCollection()
        {
            TotalWeight = 0;
            CurrentCourseActivities = new List<IClassActivity>();
        }

        public int TotalWeight { get; protected set; }
        protected List<IClassActivity> CurrentCourseActivities { get; }

        public virtual bool Add(IClassActivity classActivity)
        {
            CurrentCourseActivities.Add(classActivity);
            TotalWeight += classActivity.Weight();
            return true;
        }

        public virtual void RemoveLast()
        {
            IClassActivity classActivity = CurrentCourseActivities.RemoveLast();
            TotalWeight -= classActivity.Weight();
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
