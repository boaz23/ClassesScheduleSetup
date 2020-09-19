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

            IEnumerable<ClassSchedule> schedules = BuildSchedule(Semesters.Semester5, PracticeClassSource.GroupOnly, OverlappingPolicy.Normal, PermutationInfo.ReturnPermutationIndex);
            IEnumerable<ClassSchedule> allPermutations = BuildSchedule(Semesters.Semester5, PracticeClassSource.GroupOnly, OverlappingPolicy.AllowOverlapping, PermutationInfo.ReturnPermutationIndex);

            ScheduleInfo(schedules);
            ScheduleInfo(allPermutations);
        }

        private static void ScheduleInfo(IEnumerable<ClassSchedule> schedules)
        {
            var placements = schedules
                            .Select(x => x.CoursesPlacements.Values)
                            .ToList();

            var timesPerCourse = placements
                .Select(x => x.Select(y =>
                {
                    var classTimes = new List<ClassTime>();
                    IEnumerable<IClassActivity> classActivities = EnumerableExtensions.AsEnumerable(y.Lecture, y.PracticeClass, y.Lab);
                    foreach (IClassActivity classActivity in classActivities)
                    {
                        if (classActivity != null)
                        {
                            classTimes.AddRange(classActivity.Times);
                        }
                    }

                    return (Course: y.Course, Times: classTimes);
                }))
                .Select(x => x.ToDictionary(y => y.Course, y => y.Times))
                .ToList();

            var times = timesPerCourse
                .Select(x => x.Values.SelectMany(y => y))
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
                .Select(x => new {
                    Schedule = x.First,
                    Placements = x.Second,
                    TimesPerCourse = x.Item3,
                    Times = x.Item4,
                    Weight = x.First.Weight,
                    PermutationIndex = x.First.PermutationIndex,
                })
                .ToList();

            var orderedSchedulesInfos = zipped
                .OrderBy(x => x.Weight)
                .ToList();

            //var free = orderedSchedulesInfos
            //    .Select(schedule =>
            //    {
            //        int freeDaysCount = 0;
            //        for (DayOfWeek day = DayOfWeek.Sunday; day <= DayOfWeek.Thursday; day++)
            //        {
            //            bool found = false;
            //            foreach (ClassTime time in schedule.Times)
            //            {
            //                if (time.Day == day)
            //                {
            //                    found = true;
            //                    break;
            //                }
            //            }

            //            if (!found)
            //            {
            //                freeDaysCount++;
            //            }
            //        }

            //        return new
            //        {
            //            Schedule = schedule,
            //            FreeDaysCount = freeDaysCount,
            //            Weight = schedule.Weight,
            //            PermutationIndex = schedule.PermutationIndex,
            //        };
            //    })
            //    .OrderByDescending(x => x.FreeDaysCount)
            //    .ThenBy(x => x.Weight)
            //    .ToList();
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
                if (overlappingPolicy.HasAllOfFlags(OverlappingPolicy.SaveTimeForLaunch))
                {
                    throw new NotImplementedException();
                }

                classActivityCollection = new ClassActivityCollection();
            }
            else
            {
                // Disallow overlapping
                if (overlappingPolicy.HasAllOfFlags(OverlappingPolicy.SaveTimeForLaunch))
                {
                    classActivityCollection = new NoOverlapsAndLaunchTimeClassActivityCollection();
                }
                else
                {
                    classActivityCollection = new NoOverlapsClassActivityCollection();
                }
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
            Normal = 0,
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
