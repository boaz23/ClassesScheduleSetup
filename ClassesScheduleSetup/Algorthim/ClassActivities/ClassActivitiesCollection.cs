using System.Collections.Generic;

using ClassesScheduleSetup.ClassActivity;

using Utility.Collections.Generic;

namespace ClassesScheduleSetup
{
    internal class ClassActivitiesCollection
    {
        public ClassActivitiesCollection()
        {
            Weight = 0;
            CurrentCourseActivities = new List<IClassActivity>();
        }

        public int Weight { get; protected set; }
        protected List<IClassActivity> CurrentCourseActivities { get; }

        public virtual void Add(IClassActivity classActivity)
        {
            CurrentCourseActivities.Add(classActivity);
            Weight += classActivity.Weight();
        }

        public virtual void RemoveLast()
        {
            IClassActivity classActivity = CurrentCourseActivities.RemoveLast();
            Weight -= classActivity.Weight();
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
