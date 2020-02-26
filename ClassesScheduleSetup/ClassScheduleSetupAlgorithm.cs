using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassesScheduleSetup
{
    internal abstract class ClassScheduleSetupAlgorithm
    {
        public IEnumerable<ClassSchedule> CalculateSetup(Semester semester)
        {
            return CalculateSetup(semester.Courses)
                .OrderByDescending(x => x.Weight);
        }

        private IEnumerable<ClassSchedule> CalculateSetup(IEnumerable<Course> courses)
        {

        }
    }
}
