using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassesScheduleSetup
{
    public class CourseGroupBuilder
    {
        public CourseGroupBuilder()
        {
            PracticalClasses = new List<ClassActivityBuilder>();
            Labs = new List<ClassActivityBuilder>();
        }

        public ClassActivityBuilder Lecture { get; set; }
        public ICollection<ClassActivityBuilder> PracticalClasses { get; }
        public ICollection<ClassActivityBuilder> Labs { get; }

        public CourseGroup Build()
        {
            if (Lecture == null)
            {
                throw new InvalidOperationException("The lecture must be set first.");
            }

            IClassActivity lecture = Lecture.CreateClassActivity();
            IEnumerable<ClassAcitivity> practicalClasses = BuildClassActivities(PracticalClasses);
            IEnumerable<ClassAcitivity> labs = BuildClassActivities(Labs);
            var group = new CourseGroup(lecture, practicalClasses, labs);

            SetGroup(group, practicalClasses);
            SetGroup(group, labs);
            return group;
        }

        private static IEnumerable<ClassAcitivity> BuildClassActivities(IEnumerable<ClassActivityBuilder> classActivityBuilders)
        {
            return classActivityBuilders
                .Select(c => c.CreateClassActivity())
                .ToList();
        }

        private static void SetGroup(CourseGroup group, IEnumerable<ClassAcitivity> classAcitivities)
        {
            foreach (ClassAcitivity classAcitivity in classAcitivities)
            {
                classAcitivity.Group = group;
            }
        }
    }
}
