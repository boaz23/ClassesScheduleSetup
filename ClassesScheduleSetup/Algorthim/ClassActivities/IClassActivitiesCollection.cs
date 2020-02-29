using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesScheduleSetup
{
    public interface IClassActivitiesCollection
    {
        int TotalWeight { get; }

        bool Add(IClassActivity classActivity);
        void RemoveLast();
        CourseSchedulePlacement BuildCoursePlacement(Course course, CourseGroup group);
    }
}
