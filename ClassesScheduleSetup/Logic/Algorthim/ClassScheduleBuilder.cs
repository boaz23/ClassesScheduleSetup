using System;
using System.Collections.Generic;
using System.Linq;

using Utility.Collections.Generic;

namespace ClassesScheduleSetup
{
    internal class ClassScheduleBuilder
    {
        public ClassScheduleBuilder(IClassActivityCollection classActivitiesCollection)
        {
            if (classActivitiesCollection is null)
            {
                throw new ArgumentNullException(nameof(classActivitiesCollection));
            }

            CurrentPlacements = new List<CourseSchedulePlacement>();
            CurrentCourseActivities = classActivitiesCollection;
            InvalidScope = 0;
        }

        private IClassActivityCollection CurrentCourseActivities { get; }
        private List<CourseSchedulePlacement> CurrentPlacements { get; }
        private int InvalidScope { get; set; }

        public bool IsValid => InvalidScope == 0;

        public bool AddClassActivity(IClassActivity classActivity)
        {
            bool success;
            if (IsValid)
            {
                success = CurrentCourseActivities.Add(classActivity);
            }
            else
            {
                success = false;
            }

            if (!success)
            {
                InvalidScope++;
            }

            return success;
        }

        public void RemoveLastClassActivity()
        {
            if (IsValid)
            {
                CurrentCourseActivities.RemoveLast();
            }
            else
            {
                InvalidScope--;
            }
        }

        public void BuildCoursePlacement(Course course, CourseGroup group)
        {
            if (!IsValid)
            {
                return;
            }

            CourseSchedulePlacement placement = CurrentCourseActivities.BuildCoursePlacement(course, group);
            CurrentPlacements.Add(placement);
        }

        public void RemoveLastCoursePlacement()
        {
            if (!IsValid)
            {
                return;
            }

            CurrentPlacements.RemoveLast();
        }

        public ClassSchedule BuildSchedule(int permutationIndex)
        {
            if (!IsValid)
            {
                throw new InvalidOperationException("Cannot build schedule when in an invalid state.");
            }

            return new ClassSchedule(BuildScheduleMap(), CurrentCourseActivities.TotalWeight, permutationIndex);
        }

        private IDictionary<Course, CourseSchedulePlacement> BuildScheduleMap()
        {
            return CurrentPlacements.ToDictionary(x => x.Course);
        }
    }
}
