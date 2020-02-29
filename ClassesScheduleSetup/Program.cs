using System.Collections.Generic;
using System.ComponentModel;
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

            IEnumerable<ClassSchedule> allPermutations = BuildSchedule(Semesters.SemesterC, PracticeClassSource.GroupOnly, OverlappingPolicy.AllowOverlapping);
            IEnumerable<ClassSchedule> schedules = BuildSchedule(Semesters.SemesterC, PracticeClassSource.GroupOnly, OverlappingPolicy.DisallowOverlapping);

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

        private static IEnumerable<ClassSchedule> BuildSchedule(Semester semester, PracticeClassSource practiceClassSource, OverlappingPolicy overlappingPolicy)
        {
            IClassActivityCollection classActivitiesCollection = CreateClassActivityCollectionForPolicy(overlappingPolicy);
            ClassScheduleSetupAlgorithm algorithm = CreateAlgorithm(classActivitiesCollection, practiceClassSource);
            return algorithm.CalculateSetup(semester);
        }

        private static IClassActivityCollection CreateClassActivityCollectionForPolicy(OverlappingPolicy overlappingPolicy)
        {
            switch (overlappingPolicy)
            {
                case OverlappingPolicy.AllowOverlapping:
                    return new ClassActivityCollection();
                case OverlappingPolicy.DisallowOverlapping:
                    return new NoOverlapsClassActivityCollection();
                case OverlappingPolicy.SaveTimeForLaunch:
                    throw new System.NotImplementedException();
                default:
                    throw new InvalidEnumArgumentException(nameof(overlappingPolicy), (int)overlappingPolicy, typeof(OverlappingPolicy));
            }
        }

        private static ClassScheduleSetupAlgorithm CreateAlgorithm(IClassActivityCollection classActivitiesCollection, PracticeClassSource practiceClassSource)
        {
            switch (practiceClassSource)
            {
                case PracticeClassSource.GroupOnly:
                    return new PracticeClassFromGroupOnlySetupAlgorithm(classActivitiesCollection);
                case PracticeClassSource.AllGroups:
                    return new PracticeClassFromAllGroupsSetupAlgorithm(classActivitiesCollection);
                default:
                    throw new InvalidEnumArgumentException(nameof(practiceClassSource), (int)practiceClassSource, typeof(PracticeClassSource));
            }
        }

        private enum PracticeClassSource
        {
            GroupOnly,
            AllGroups,
        }

        private enum OverlappingPolicy
        {
            AllowOverlapping = 1,
            DisallowOverlapping = 2,
            SaveTimeForLaunch = 4,
        }
    }
}
