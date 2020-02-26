using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassesScheduleSetup
{
    internal static partial class Semesters
    {
        static Semesters()
        {
            SemesterC = WeighClasses(SemesterC_Builder()).Build();
        }

        public static Semester SemesterC { get; }

        private static Semester.Builder WeighClasses(Semester.Builder semester)
        {
            foreach (Course.Builder course in semester.Courses)
            {
                foreach (CourseGroup.Builder group in course.Groups)
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

        private static IEnumerable<ClassActivityBuilder> GetClassActivities(CourseGroup.Builder group)
        {
            return EnumerableExtensions.AsEnumerable(group.Lecture)
                .Concat(group.PracticalClasses)
                .Concat(group.Labs);
        }

        private static IEnumerable<ClassTime> GetClassTimes(ClassActivityBuilder classActivity)
        {
            IEnumerable<ClassTime> classTimes = classActivity.GetClassTimes();
            classActivity.ClearAllTimes();
            classActivity.ClassTimes_Concreate.AddAll(classTimes);
            return classTimes;
        }

        private static void WeightActivity(ClassActivityBuilder classActivity, ClassTime classTime)
        {
            if (classTime.Day == DayOfWeek.Thursday)
            {
                WeighClassActivity_Thursday(classActivity, classTime);
            }
            else
            {
                WeightClassActivity_OtherDay(classActivity, classTime);
            }
        }

        private static void WeighClassActivity_Thursday(ClassActivityBuilder classActivity, ClassTime classTime)
        {
            switch (classTime.End.Hour)
            {
                case 13:
                    classActivity.Weight += (int)ClassWeights.Thursday_EndsIn1PM;
                    break;
                case 14:
                    classActivity.Weight += (int)ClassWeights.Thursday_EndsIn2PM;
                    break;
                case 15:
                    classActivity.Weight += (int)ClassWeights.Thursday_EndsIn3PM;
                    break;
                case 16:
                    classActivity.Weight += (int)ClassWeights.Thursday_EndsIn4PM;
                    break;
                case 17:
                    classActivity.Weight += (int)ClassWeights.Thursday_EndsIn5PM;
                    break;
                case 18:
                    classActivity.Weight += (int)ClassWeights.Thursday_EndsIn6PM;
                    break;
                default:
                    break;
            }
        }

        private static void WeightClassActivity_OtherDay(ClassActivityBuilder classActivity, ClassTime classTime)
        {
            switch (classTime.End.Hour)
            {
                case 17:
                    classActivity.Weight += (int)ClassWeights.EndsIn5PM;
                    break;
                case 18:
                    classActivity.Weight += (int)ClassWeights.EndsIn6PM;
                    break;
                case 19:
                    classActivity.Weight += (int)ClassWeights.EndsIn7PM;
                    break;
                case 20:
                    classActivity.Weight += (int)ClassWeights.EndsIn8PM;
                    break;
                default:
                    break;
            }
        }
    }
}
