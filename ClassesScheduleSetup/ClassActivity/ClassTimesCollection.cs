using System;
using System.Collections.Generic;

namespace ClassesScheduleSetup.ClassActivity
{
    public class ClassTimesCollection
    {
        public ClassTimesCollection()
        {
            ClassTimes = new List<ClassTime>();
        }

        private List<ClassTime> ClassTimes { get; }

        public bool AddAlIfNoneOverlap(IEnumerable<ClassTime> classTimes)
        {
            if (classTimes is null)
            {
                throw new ArgumentNullException(nameof(classTimes));
            }

            if (Overlaps(classTimes))
            {
                return false;
            }

            AddAll(classTimes);
            return true;
        }

        public bool Overlaps(IEnumerable<ClassTime> classTimes)
        {
            foreach (ClassTime classTime in classTimes)
            {
                if (Overlaps(classTime))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Overlaps(ClassTime classTime)
        {
            foreach (ClassTime taken in ClassTimes)
            {
                if (taken.Overlaps(classTime))
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(ClassTime classTime)
        {
            for (int i = ClassTimes.Count - 1; i >= 0; )
            {
                ClassTime? union = classTime.UnionIfOverlapsOrContinousWith(ClassTimes[i]);
                if (union.HasValue)
                {
                    ClassTimes.RemoveAt(i);
                    classTime = union.Value;
                }
            }

            ClassTimes.Add(classTime);
        }

        public void AddAll(IEnumerable<ClassTime> classTimes)
        {
            foreach (ClassTime classTime in classTimes)
            {
                Add(classTime);
            }
        }
    }
}
