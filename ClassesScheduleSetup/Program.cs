using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Utility.Linq;

namespace ClassesScheduleSetup
{
    class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("he-IL");

            IEnumerable<ClassSchedule> schedules = BuildSchedule(Semesters.SemesterC, false);

            var placements = schedules
                .Select(x => x.CoursesPlacements.Values)
                .ToList();

            var timesPerCourse = placements
                .Select(x => x.Select(y =>
                {
                    IEnumerable<ClassTime> classTimes = Enumerable.Empty<ClassTime>();
                    IEnumerable<IClassActivity> classActivities = EnumerableExtensions.AsEnumerable(y.Lecture, y.PracticeClass, y.Lab);
                    foreach (IClassActivity classActivity in classActivities)
                    {
                        if (classActivity != null)
                        {
                            classTimes = classTimes.Concat(classActivity.Times);
                        }
                    }

                    return classTimes;
                }))
                .Select(x => x
                    .Select(y => y.ToList())
                    .ToList()
                )
                .ToList();

            var times = timesPerCourse
                .Select(x => x.SelectMany(y => y))
                .Select(x => x
                    .OrderBy(y => y.Day)
                    .ThenBy(y => y.Start)
                    .ToList()
                )
                .ToList();

            var zipped = schedules
                .Zip(placements)
                .Zip(timesPerCourse, (tuple, second) => (tuple.First, tuple.Second, second))
                .Zip(times, (tuple, second) => (tuple.First, tuple.Second, tuple.second, second))
                .Select(x => (Schedule: x.First, Placements: x.Second, TimesPerCourse: x.Item3, Times: x.Item4))
                .ToList();

            var orderedSchedules = schedules
                .OrderBy(x => x.Weight)
                .ToList();
        }

        private static IEnumerable<ClassSchedule> BuildSchedule(Semester semester, bool takePracticeClassFromAllGroups)
        {
            IClassActivityCollection classActivitiesCollection = new ClassActivitiesCollection();
            ClassScheduleSetupAlgorithm algorithm;
            if (takePracticeClassFromAllGroups)
            {
                algorithm = new PracticeClassFromAllGroupsSetupAlgorithm(classActivitiesCollection);
            }
            else
            {
                algorithm = new PracticeClassFromGroupOnlySetupAlgorithm(classActivitiesCollection);
            }

            return algorithm.CalculateSetup(semester);
        }
    }
}
