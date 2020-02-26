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
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Sunday, "14:00", "16:00"),
                                        new ClassTimeBuilder(DayOfWeek.Monday, "14:00", "16:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "18:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 13,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 2,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Sunday,  "12:00", "14:00"),
                                        new ClassTimeBuilder(DayOfWeek.Tuesday, "16:00", "18:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 21,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "14:00", "16:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 22,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "18:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 23,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "12:00", "14:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 3,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Monday,  "16:00", "18:00"),
                                        new ClassTimeBuilder(DayOfWeek.Tuesday, "14:00", "16:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 31,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "12:00", "14:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 32,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 33,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "08:00", "10:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 4,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Sunday, "15:00", "17:00"),
                                        new ClassTimeBuilder(DayOfWeek.Monday, "10:00", "12:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 41,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 42,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "16:00", "18:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 43,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "10:00", "12:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 5,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Sunday,  "12:00", "14:00"),
                                        new ClassTimeBuilder(DayOfWeek.Tuesday, "10:00", "12:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 51,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "18:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 52,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "12:00", "14:00"),
                                    },
                                },
                            },
                        },
                    },
                    new Course.Builder
                    {
                        Name = "ארכיטקטורה במחשבים ומעבדה בתכנות מערכות",
                        Id = "202.1.2091",
                        Groups =
                        {
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "16:00", "19:00"),
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "16:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "16:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 13,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "15:00", "16:00"),
                                    },
                                },
                                Labs =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 15,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 16,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 17,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "17:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 18,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "17:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 19,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 20,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 34,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 35,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "17:00", "20:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 2,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "09:00", "12:00"),
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 21,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "18:00", "19:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 22,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "18:00", "19:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 23,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "19:00", "20:00"),
                                    },
                                },
                                Labs =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 25,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "17:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 26,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "17:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 27,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "17:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 28,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 29,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 32,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 33,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 37,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "18:00", "21:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 4,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "09:00", "12:00"),
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 41,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "12:00", "13:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 42,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "13:00", "14:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 43,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "17:00", "18:00"),
                                    },
                                },
                                Labs =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 44,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "17:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 45,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 46,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 47,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 48,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "17:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 49,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "17:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 50,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 62,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "17:00", "20:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 5,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "09:00", "12:00"),
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 51,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "11:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 52,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "12:00", "13:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 60,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "13:00", "14:00"),
                                    },
                                },
                                Labs =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 53,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 54,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 55,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 56,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 57,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 59,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "14:00", "17:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 61,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "09:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 63,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "09:00", "12:00"),
                                    },
                                },
                            },
                        },
                    },
                    new Course.Builder
                    {
                        Name = "מודלים חישוביים",
                        Id = "202.1.2011",
                        Groups =
                        {
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Sunday, "12:00", "14:00"),
                                        new ClassTimeBuilder(DayOfWeek.Monday, "12:00", "14:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "12:00", "14:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "10:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 13,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "18:00", "20:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 2,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Sunday,    "10:00", "12:00"),
                                        new ClassTimeBuilder(DayOfWeek.Wednesday, "16:00", "18:00"),
                                    },
                                    Weight = ClassWeights.Sebastian_Ben_Daniel,
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 21,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "18:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 22,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "12:00", "14:00"),
                                        Weight = ClassWeights.Shahaf_Finder,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 23,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00"),
                                        Weight = ClassWeights.Shahaf_Finder,
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 3,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Monday,  "14:00", "16:00"),
                                        new ClassTimeBuilder(DayOfWeek.Tuesday, "16:00", "18:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 31,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "08:00", "10:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 32,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "14:00", "16:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 33,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "18:00", "20:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 4,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Sunday,  "13:00", "15:00"),
                                        new ClassTimeBuilder(DayOfWeek.Tuesday, "14:00", "16:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 41,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "18:00", "20:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 42,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "16:00", "18:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 43,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "14:00", "16:00"),
                                    },
                                },
                            },
                            new CourseGroup.Builder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 5,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Sunday,  "17:00", "19:00"),
                                        new ClassTimeBuilder(DayOfWeek.Tuesday, "16:00", "18:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 51,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "16:00", "18:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 52,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "12:00", "14:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 53,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00"),
                                    },
                                },
                            },
                        },
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
                                        new ClassTimeBuilder(DayOfWeek.Tuesday,  "12:00", "14:00"),
                                        new ClassTimeBuilder(DayOfWeek.Thursday, "10:00", "12:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "12:00", "14:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 13,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "16:00", "18:00"),
                                    },
                                },
                            },
                        },
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
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "09:00", "12:00"),
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "12:00", "13:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "13:00", "14:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 13,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "16:00", "17:00"),
                                    },
                                },
                            },
                        },
                    },
                },
            };
        }
    }
}
