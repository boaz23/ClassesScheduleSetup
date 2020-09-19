using System;

namespace ClassesScheduleSetup
{
    internal static partial class Semesters
    {
        private static Semester.Builder Semester5_Builder()
        {
            return new Semester.Builder
            {
                Courses =
                {
                    new CourseBuilder
                    {
                        Name = "עקרונות הקומפילציה",
                        Id = "202.1.3021",
                        Groups =
                        {
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Tuesday,  "16:00", "18:00"),
                                        new ClassTimeBuilder(DayOfWeek.Thursday, "14:00", "16:00"),
                                    },
                                    Weight = (ClassActivityWeight)((int)ClassActivityWeight.EndsIn6PM + (int)ClassActivityWeight.Thursday_EndsIn4PM),
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "13:00", "14:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "12:00", "13:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 13,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "17:00", "18:00"),
                                        Weight = ClassActivityWeight.EndsIn6PM,
                                    },
                                },
                            },
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 2,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Tuesday,  "10:00", "12:00"),
                                        new ClassTimeBuilder(DayOfWeek.Thursday, "09:00", "11:00"),
                                    },
                                    Weight = ClassActivityWeight.StartsIn9AM,
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 21,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "18:00", "19:00"),
                                        Weight = ClassActivityWeight.EndsIn7PM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 22,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "10:00", "11:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 23,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "16:00", "17:00"),
                                        Weight = ClassActivityWeight.EndsIn5PM,
                                    },
                                },
                            },
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 3,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Tuesday,  "14:00", "16:00"),
                                        new ClassTimeBuilder(DayOfWeek.Thursday, "12:00", "14:00"),
                                    },
                                    Weight = ClassActivityWeight.Thursday_EndsIn2PM,
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 31,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "16:00", "17:00"),
                                        Weight = ClassActivityWeight.EndsIn5PM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 32,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "18:00", "19:00"),
                                        Weight = ClassActivityWeight.EndsIn7PM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 33,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "17:00", "18:00"),
                                        Weight = ClassActivityWeight.EndsIn6PM,
                                    },
                                },
                            },
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 4,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Tuesday,  "08:00", "10:00"),
                                        new ClassTimeBuilder(DayOfWeek.Thursday, "16:00", "18:00"),
                                    },
                                    Weight = (ClassActivityWeight)((int)ClassActivityWeight.StartsIn8AM + (int)ClassActivityWeight.Thursday_EndsIn6PM),
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 41,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "15:00", "16:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 42,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "17:00", "18:00"),
                                        Weight = ClassActivityWeight.EndsIn6PM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 43,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "19:00", "20:00"),
                                        Weight = ClassActivityWeight.EndsIn8PM,
                                    },
                                },
                            },
                        },
                    },
                    new CourseBuilder
                    {
                        Name = "יסודות הנדסת תוכנה",
                        Id = "202.1.3051",
                        Groups =
                        {
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "10:00", "13:00"),
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "16:00", "17:00"),
                                        Weight = ClassActivityWeight.EndsIn5PM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "17:00", "18:00"),
                                        Weight = ClassActivityWeight.EndsIn6PM,
                                    },
                                },
                            },
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 2,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Thursday, "09:00", "12:00"),
                                    Weight = ClassActivityWeight.StartsIn9AM,
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 21,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "17:00", "18:00"),
                                        Weight = ClassActivityWeight.EndsIn6PM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 22,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "18:00", "19:00"),
                                        Weight = ClassActivityWeight.EndsIn7PM,
                                    },
                                },
                            },
                        },
                    },
                    new CourseBuilder
                    {
                        Name = "הנדסת איכות תוכנה",
                        Id = "372.1.3501",
                        Groups =
                        {
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "10:00", "13:00"),
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "12:00", "13:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "13:00", "14:00"),
                                    },
                                },
                            },
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 2,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Tuesday, "14:00", "17:00"),
                                    Weight = ClassActivityWeight.EndsIn5PM,
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 21,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "10:00", "11:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 22,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "11:00", "12:00"),
                                    },
                                },
                            },
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 3,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "14:00", "17:00"),
                                    Weight = ClassActivityWeight.EndsIn5PM,
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 31,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "17:00", "18:00"),
                                        Weight = ClassActivityWeight.EndsIn6PM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 32,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "18:00", "19:00"),
                                        Weight = ClassActivityWeight.EndsIn7PM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 33,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "19:00", "20:00"),
                                        Weight = ClassActivityWeight.EndsIn8PM,
                                    },
                                },
                            },
                        },
                    },
                    new CourseBuilder
                    {
                        Name = "עיצוב ומימוש של מנשקי אדם",
                        Id = "372.1.3107",
                        Groups =
                        {
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "12:00", "15:00"),
                                },
                                PracticalClasses =
                                {
                                },
                            },
                        },
                    },
                    new CourseBuilder
                    {
                        Name = "מבוא לתקשורת נתונים",
                        Id = "372.1.3041",
                        Groups =
                        {
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "09:00", "12:00"),
                                    Weight = ClassActivityWeight.StartsIn9AM,
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "08:00", "09:00"),
                                        Weight = ClassActivityWeight.StartsIn8AM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "09:00", "10:00"),
                                        Weight = ClassActivityWeight.StartsIn9AM,
                                    },
                                },
                            },
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 2,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Wednesday, "14:00", "17:00"),
                                    Weight = ClassActivityWeight.EndsIn5PM,
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 21,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "11:00", "12:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 22,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "15:00", "16:00"),
                                    },
                                },
                            },
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 3,
                                    ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "09:00", "12:00"),
                                    Weight = ClassActivityWeight.StartsIn9AM,
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 31,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "16:00", "17:00"),
                                        Weight = ClassActivityWeight.EndsIn5PM,
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 32,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "14:00", "15:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 33,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Sunday, "15:00", "16:00"),
                                    },
                                },
                            },
                        },
                    },
                    new CourseBuilder
                    {
                        Name = "אנליזה נומרית ואופטימיזציה להנדסת נתונים",
                        Id = "382.1.2705",
                        Groups =
                        {
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 1,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Wednesday, "09:00", "12:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 11,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "15:00", "16:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 12,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "18:00", "19:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 13,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "19:00", "20:00"),
                                    },
                                },
                            },
                            new CourseGroupBuilder
                            {
                                Lecture = new ClassActivityBuilder
                                {
                                    ActivityId = 2,
                                    ClassTimes =
                                    {
                                        new ClassTimeBuilder(DayOfWeek.Wednesday, "14:00", "17:00"),
                                    },
                                },
                                PracticalClasses =
                                {
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 21,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "13:00", "14:00"),
                                    },
                                    new ClassActivityBuilder
                                    {
                                        ActivityId = 22,
                                        ClassTime = new ClassTimeBuilder(DayOfWeek.Monday, "17:00", "18:00"),
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
