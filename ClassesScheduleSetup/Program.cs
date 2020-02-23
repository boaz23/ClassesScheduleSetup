using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Linq.Enumerable;

namespace ClassesScheduleSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("he-IL");
            IEnumerable<Course> courses = SemesterCourses();
        }

        private static IEnumerable<Course> SemesterCourses()
        {
            return BuildCourses(SemesterCoursesBuilders());
        }
        private static IEnumerable<Course> BuildCourses(IEnumerable<Course.Builder> courses)
        {
            return courses
                .Select(c => c.Build())
                .ToList();
        }
        private static IEnumerable<Course.Builder> SemesterCoursesBuilders()
        {
            return new Course.Builder[] {
                new Course.Builder
                {
                    Name = "עקרונות שפות תכנות",
                    Id = "202.1.2051",
                    Groups =
                    {

                    }
                },
                new Course.Builder
                {
                    Name = "ניתוח ועיצוב מערכות תוכנה",
                    Id = "372.1.3401",
                    Groups =
                    {
                        new CourseGroup.Builder
                        {
                            Lecture = new ClassActivityBuilder
                            {
                                ActivityId = 1,
                                ClassTimes =
                                {
                                    new ClassTimeBuilder(DayOfWeek.Tuesday, "12:00", "14:00"),
                                    new ClassTimeBuilder(DayOfWeek.Thursday, "10:00", "12:00")
                                }
                            },
                            PracticalClasses =
                            {
                                new ClassActivityBuilder
                                {
                                    ActivityId = 11,
                                    Time = new ClassTimeBuilder(DayOfWeek.Thursday, "12:00", "14:00")
                                },
                                new ClassActivityBuilder
                                {
                                    ActivityId = 12,
                                    Time = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00")
                                },
                                new ClassActivityBuilder
                                {
                                    ActivityId = 13,
                                    Time = new ClassTimeBuilder(DayOfWeek.Thursday, "16:00", "18:00")
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
