using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesScheduleSetup
{
    internal class Semester
    {
        internal Semester(IEnumerable<Course> courses)
        {
            if (courses is null)
            {
                throw new ArgumentNullException(nameof(courses));
            }
            if (!courses.Any())
            {
                throw new ArgumentException("Courses cannot be empty.", nameof(courses));
            }

            Courses = courses;
        }

        public IEnumerable<Course> Courses { get; }

        public class Builder
        {
            public Builder()
            {
                Courses = new List<CourseBuilder>();
            }

            public ICollection<CourseBuilder> Courses { get; }

            public Semester Build()
            {
                return new Semester(BuildCourses(Courses));
            }

            private static IEnumerable<Course> BuildCourses(IEnumerable<CourseBuilder> courses)
            {
                return courses
                    .Select(c => c.Build())
                    .ToList();
            }
        }
    }
}
