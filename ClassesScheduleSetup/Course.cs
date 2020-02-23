using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace ClassesScheduleSetup
{
    internal class Course
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

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }

        public class Builder
        {
            public Builder()
            {
                Groups = new List<CourseGroup.Builder>();
            }

            public string Id { get; set; }
            public string Name { get; set; }
            public ICollection<CourseGroup.Builder> Groups { get; }

            public Course Build()
            {
                return new Course(Id, Name, CreateGroups(Groups));
            }

            private static IEnumerable<CourseGroup> CreateGroups(IEnumerable<CourseGroup.Builder> groups)
            {
                return groups
                    .Select(g => g.Build())
                    .ToList();
            }
        }
    }
}
