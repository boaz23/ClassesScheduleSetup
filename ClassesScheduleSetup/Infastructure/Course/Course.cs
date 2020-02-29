using System;
using System.Collections.Generic;

using static System.Linq.Enumerable;

namespace ClassesScheduleSetup
{
    public class Course
    {
        public Course(string id, string name, IEnumerable<CourseGroup> groups)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("The id cannot be null or empty.", nameof(id));
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The name cannot be null or empty", nameof(name));
            }
            if (groups is null)
            {
                throw new ArgumentNullException(nameof(groups));
            }
            if (!groups.Any())
            {
                throw new ArgumentException("The groups cannot be empty.", nameof(groups));
            }

            Id = id;
            Name = name;
            Groups = groups;
        }

        public string Id { get; }
        public string Name { get; }
        public IEnumerable<CourseGroup> Groups { get; }

        public override bool Equals(object obj)
        {
            if (obj is Course course)
            {
                return Id == course.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode(StringComparison.CurrentCulture);
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
