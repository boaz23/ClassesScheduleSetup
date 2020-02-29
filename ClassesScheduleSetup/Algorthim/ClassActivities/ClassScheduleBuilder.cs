using System;
using System.Collections.Generic;
using System.Linq;

using Utility.Collections.Generic;

namespace ClassesScheduleSetup
{
    internal class ClassScheduleBuilder
    {
        public ClassScheduleBuilder(IClassActivitiesCollection classActivitiesCollection)
        {
            if (classActivitiesCollection is null)
            {
                throw new ArgumentNullException(nameof(classActivitiesCollection));
            }

            CurrentPlacements = new List<CourseSchedulePlacement>();
            CurrentCourseActivities = classActivitiesCollection;
        }

        private IClassActivitiesCollection CurrentCourseActivities { get; }
        private List<CourseSchedulePlacement> CurrentPlacements { get; }

        public bool AddClassActivity(IClassActivity classActivity)
        {
            return CurrentCourseActivities.Add(classActivity);
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
            return new ClassSchedule(BuildScheduleMap(), CurrentCourseActivities.TotalWeight);
        }

        private IDictionary<Course, CourseSchedulePlacement> BuildScheduleMap()
        {
            return CurrentPlacements.ToDictionary(x => x.Course);
        }
    }
}
