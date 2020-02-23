using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesScheduleSetup
{
    internal interface IClassActivity
    {
        int ActivityId { get; }
        int Weight { get; }
        CourseGroup Group { get; }
        IEnumerable<ClassTime> Times { get; }
    }
}
