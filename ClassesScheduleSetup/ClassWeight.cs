using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesScheduleSetup
{
    internal enum ClassWeights
    {
        Normal = 0,
        EndsIn8PM = 1 << 10,
        Thursday_EndsIn12PM = Normal,
        Thursday_EndsIn1PM = 1 << 5,
        Thursday_EndsIn2PM = 1 << 6,
        Thursday_EndsIn3PM = 1 << 12,
        Thursday_EndsIn4PM = 1 << 13,
        Thursday_EndsIn5PM = 1 << 14,
        Thursday_EndsIn6PM = 1 << 15,
    }
}
