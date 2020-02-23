using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesScheduleSetup
{
    internal interface IClassActivity
    {
        int ActivityId { get; }
        CourseGroup Group { get; }
        IEnumerable<ClassTime> Times { get; }
    }
}
