using System;

namespace ClassesScheduleSetup
{
    internal static partial class Semesters
    {
        private static Semester.Builder SemesterC_Builder()
        {
            return new Semester.Builder
            {
                Courses =
                {
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
                        Name = "ארכיטקטורה במחשבים ומעבדה בתכנות מערכות",
                        Id = "202.1.2091",
                        Groups =
                        {

                        }
                    },
                    new Course.Builder
                    {
                        Name = "מודלים חישוביים",
                        Id = "202.1.2011",
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
                                        new ClassTimeBuilder(DayOfWeek.Thursday, "10:00", "12:00"),
                                    },
                                    Weight = ClassWeights.Thursday_EndsIn12PM
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        Time = new ClassTimeBuilder(DayOfWeek.Thursday, "12:00", "14:00"),
                                        Weight = ClassWeights.Thursday_EndsIn2PM
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        Time = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00"),
                                        Weight = ClassWeights.Thursday_EndsIn4PM
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 13,
                                        Time = new ClassTimeBuilder(DayOfWeek.Thursday, "16:00", "18:00"),
                                        Weight = ClassWeights.Thursday_EndsIn6PM
                                    }
                                }
                            }
                        }
                    },
                    new Course.Builder
                    {
                        Name = "סטטיסטיקה להנדסת תוכנה",
                        Id = "372.1.3071",
                        Groups =
                        {
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    Time = new ClassTimeBuilder(DayOfWeek.Wednesday, "09:00", "12:00")
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        Time = new ClassTimeBuilder(DayOfWeek.Wednesday, "12:00", "13:00")
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        Time = new ClassTimeBuilder(DayOfWeek.Wednesday, "13:00", "14:00")
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 13,
                                        Time = new ClassTimeBuilder(DayOfWeek.Wednesday, "16:00", "17:00")
                                    }
                                }
                            }
                        }
                    },
                }
            };
        }
    }
}
