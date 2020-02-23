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
            IEnumerable<Course> courses = Semesters.SemesterC.Courses;
        }
    }
}
