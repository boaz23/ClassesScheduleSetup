using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesScheduleSetup
{
    internal enum ClassWeights
    {
        Normal = 0,

        EndsIn5PM = 2,
        EndsIn6PM = 8,
        EndsIn7PM = 160,
        EndsIn8PM = 800,

        Thursday_EndsIn1PM = 10,
        Thursday_EndsIn2PM = 20,
        Thursday_EndsIn3PM = 40,
        Thursday_EndsIn4PM = 80,
        Thursday_EndsIn5PM = 4000,
        Thursday_EndsIn6PM = 20000,

        Sebastian_Ben_Daniel = -30000,
        Shahaf_Finder = -25000,
    }
}
