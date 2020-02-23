using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesScheduleSetup
{
    internal interface IClassActivity
    {
        int ActivityId { get; }
        CourseGroup Group { get; }
        ClassTime Time { get; }
    }
}
