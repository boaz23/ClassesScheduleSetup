using System.Collections.Generic;
using System.Linq;

using Utility.Collections.Generic;

namespace ClassesScheduleSetup
{
    internal class ClassScheduleBuilder
    {
        public ClassScheduleBuilder()
        {
            CurrentPlacements = new List<CourseSchedulePlacement>();
            CurrentCourseActivities = new ClassActivitiesCollection();
        }

        private ClassActivitiesCollection CurrentCourseActivities { get; }
        private List<CourseSchedulePlacement> CurrentPlacements { get; }

        public void AddClassActivity(IClassActivity classActivity)
        {
            CurrentCourseActivities.Add(classActivity);
        }

        public void RemoveLastClassActivity()
        {
            CurrentCourseActivities.RemoveLast();
        }

        public void BuildCoursePlacement(Course course, CourseGroup group)
        {
            CourseSchedulePlacement placement = CurrentCourseActivities.BuildCoursePlacement(course, group);
            CurrentPlacements.Add(placement);
        }

        public void RemoveLastCoursePlacement()
        {
            CurrentPlacements.RemoveLast();
        }

        public ClassSchedule BuildSchedule()
        {
            return new ClassSchedule(BuildScheduleMap(), CurrentCourseActivities.Weight);
        }

        private IDictionary<Course, CourseSchedulePlacement> BuildScheduleMap()
        {
            return CurrentPlacements.ToDictionary(x => x.Course);
        }
    }
}
