using System.Collections.Generic;
using System.Linq;

namespace ClassesScheduleSetup
{
    public class CourseBuilder
    {
        public CourseBuilder()
        {
            Groups = new List<CourseGroupBuilder>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<CourseGroupBuilder> Groups { get; }

        public Course Build()
        {
            return new Course(Id, Name, CreateGroups(Groups));
        }

        private static IEnumerable<CourseGroup> CreateGroups(IEnumerable<CourseGroupBuilder> groups)
        {
            return groups
                .Select(g => g.Build())
                .ToList();
        }
    }
}
