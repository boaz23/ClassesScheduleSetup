using System;
using System.Collections.Generic;
using System.Linq;

using Utility.Collections.Generic;
using Utility.Linq;

namespace ClassesScheduleSetup
{
    internal static partial class Semesters
    {
        private delegate void WeighActivityHour(ClassActivityBuilder classActivity, int hour);

        static Semesters()
        {
            SemesterC = WeighClasses(SemesterC_Builder()).Build();
        }

        public static Semester SemesterC { get; }

        private static Semester.Builder WeighClasses(Semester.Builder semester)
        {
            foreach (CourseBuilder course in semester.Courses)
            {
                foreach (CourseGroupBuilder group in course.Groups)
                {
                    IEnumerable<ClassActivityBuilder> classActivities = GetClassActivities(group);
                    foreach (ClassActivityBuilder classActivity in classActivities)
                    {
                        IEnumerable<ClassTime> classTimes = GetClassTimes(classActivity);
                        foreach (ClassTime classTime in classTimes)
                        {
                            WeightActivity(classActivity, classTime);
                        }
                    }
                }
            }

            return semester;
        }

        private static IEnumerable<ClassActivityBuilder> GetClassActivities(CourseGroupBuilder group)
        {
            return EnumerableExtensions.AsEnumerable(group.Lecture)
                .Concat(group.PracticalClasses)
                .Concat(group.Labs);
        }

        private static IEnumerable<ClassTime> GetClassTimes(ClassActivityBuilder classActivity)
        {
            IEnumerable<ClassTime> classTimes = classActivity.GetClassTimes();
            if (classTimes != null)
            {
                classActivity.ClearAllTimes();
                classActivity.ClassTimes_Concreate.AddAll(classTimes);
            }
            return classTimes;
        }

        private static void WeightActivity(ClassActivityBuilder classActivity, ClassTime classTime)
        {
            WeighActivityHour weightFunc;
            if (classTime.Day == DayOfWeek.Thursday)
            {
                weightFunc = WeighClassActivity_Thursday;
            }
            else
            {
                weightFunc = WeighClassActivity_OtherDay;
            }

            WeighClassActivity(classActivity, classTime, weightFunc);
        }

        private static void WeighClassActivity(ClassActivityBuilder classActivity, ClassTime classTime, WeighActivityHour weightFunc)
        {
            for (int hour = classTime.Start.Hour + 1; hour <= classTime.End.Hour; hour++)
            {
                weightFunc(classActivity, hour);
            }
        }

        private static void WeighClassActivity_Thursday(ClassActivityBuilder classActivity, int hour)
        {
            switch (hour)
            {
                case 13:
                    classActivity.Weight += (int)ClassActivityWeight.Thursday_EndsIn1PM;
                    break;
                case 14:
                    classActivity.Weight += (int)ClassActivityWeight.Thursday_EndsIn2PM;
                    break;
                case 15:
                    classActivity.Weight += (int)ClassActivityWeight.Thursday_EndsIn3PM;
                    break;
                case 16:
                    classActivity.Weight += (int)ClassActivityWeight.Thursday_EndsIn4PM;
                    break;
                case 17:
                    classActivity.Weight += (int)ClassActivityWeight.Thursday_EndsIn5PM;
                    break;
                case 18:
                    classActivity.Weight += (int)ClassActivityWeight.Thursday_EndsIn6PM;
                    break;
                default:
                    break;
            }
        }

        private static void WeighClassActivity_OtherDay(ClassActivityBuilder classActivity, int hour)
        {
            switch (hour)
            {
                case 17:
                    classActivity.Weight += (int)ClassActivityWeight.EndsIn5PM;
                    break;
                case 18:
                    classActivity.Weight += (int)ClassActivityWeight.EndsIn6PM;
                    break;
                case 19:
                    classActivity.Weight += (int)ClassActivityWeight.EndsIn7PM;
                    break;
                case 20:
                    classActivity.Weight += (int)ClassActivityWeight.EndsIn8PM;
                    break;
                default:
                    break;
            }
        }
    }
}
