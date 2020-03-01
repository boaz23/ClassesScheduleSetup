using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

using Utility;
using Utility.Linq;

namespace ClassesScheduleSetup
{
    class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("he-IL");

            IEnumerable<ClassSchedule> allPermutations = BuildSchedule(Semesters.SemesterC, PracticeClassSource.GroupOnly, OverlappingPolicy.AllowOverlapping, PermutationInfo.NoInfo);
            IEnumerable<ClassSchedule> schedules = BuildSchedule(Semesters.SemesterC, PracticeClassSource.GroupOnly, OverlappingPolicy.None, PermutationInfo.ReturnPermutationIndex);

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

        // TODO: fix to work with all parameters
        private static IEnumerable<ClassSchedule> BuildSchedule
        (
            Semester semester,
            PracticeClassSource practiceClassSource,
            OverlappingPolicy overlappingPolicy,
            PermutationInfo permutationInfo
        )
        {
            IClassActivityCollection classActivitiesCollection = CreateClassActivityCollectionForPolicy(overlappingPolicy);
            ClassScheduleSetupAlgorithm algorithm = CreateAlgorithm(classActivitiesCollection, practiceClassSource);
            return algorithm.CalculateSetup(semester);
        }

        private static IClassActivityCollection CreateClassActivityCollectionForPolicy(OverlappingPolicy overlappingPolicy)
        {
            if ((int)overlappingPolicy < 0 || (int)overlappingPolicy > 3)
            {
                throw new InvalidEnumArgumentException(nameof(overlappingPolicy), (int)overlappingPolicy, typeof(OverlappingPolicy));
            }

            IClassActivityCollection classActivityCollection;
            if (overlappingPolicy.HasAllOfFlags(OverlappingPolicy.AllowOverlapping))
            {
                classActivityCollection = new ClassActivityCollection();
            }
            else
            {
                // Disallow overlapping
                classActivityCollection = new NoOverlapsClassActivityCollection();
            }

            if (overlappingPolicy.HasAllOfFlags(OverlappingPolicy.SaveTimeForLaunch))
            {
                throw new NotImplementedException();
            }

            return classActivityCollection;
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
            None = 0,
            AllowOverlapping = 1,
            SaveTimeForLaunch = 2,
            All = -1,
        }

        private enum PermutationInfo
        {
            NoInfo,
            ReturnPermutationIndex,
        }
    }
}
