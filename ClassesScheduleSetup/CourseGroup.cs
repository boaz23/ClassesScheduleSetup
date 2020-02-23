using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace ClassesScheduleSetup
{
    internal class CourseGroup
    {
        public CourseGroup(int groupId, IClassActivity lecture, IEnumerable<IClassActivity> practicalClasses, IEnumerable<IClassActivity> labs)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException("The group id must be positive.", nameof(groupId));
            }
            if (lecture is null)
            {
                throw new ArgumentNullException(nameof(lecture));
            }
            if (practicalClasses is null)
            {
                throw new ArgumentNullException(nameof(practicalClasses));
            }
            if (labs is null)
            {
                throw new ArgumentNullException(nameof(labs));
            }

            Id = groupId;
            Lecture = lecture;
            PracticalClasses = practicalClasses;
            Labs = labs;
        }

        public int Id { get; }
        public IClassActivity Lecture { get; }
        public IEnumerable<IClassActivity> PracticalClasses { get; }
        public IEnumerable<IClassActivity> Labs { get; }

        internal class Builder
        {
            public Builder()
            {
                PracticalClasses = new List<ClassActivityBuilder>();
                Labs = new List<ClassActivityBuilder>();
            }

            public int Id { get; set; }
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
                var group = new CourseGroup(Id, lecture, practicalClasses, labs);

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
}
