using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Linq.Enumerable;

namespace ClassesScheduleSetup
{
    class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("he-IL");
            var schedules = BuildSchedule(Semesters.SemesterC, false)
                //.OrderByDescending(x => x.Weight)
                .Select(x => x.CoursesPlacements.Values)
                .ToList();
        }

        private static IEnumerable<ClassSchedule> BuildSchedule(Semester semester, bool takePracticeClassFromAllGroups)
        {
            ClassScheduleSetupAlgorithm algorithm;
            if (takePracticeClassFromAllGroups)
            {
                algorithm = new PracticeClassFromAllGroupsSetupAlgorithm();
            }
            else
            {
                algorithm = new PracticeClassFromGroupOnlySetupAlgorithm();
            }

            return algorithm.CalculateSetup(semester);
        }
    }
}
