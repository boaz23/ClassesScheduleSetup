using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassesScheduleSetup
{
    // TODO: refactor to use an interval tree
    public class ClassTimesCollection : IEnumerable<ClassTime>, ICloneable
    {
        public ClassTimesCollection()
        {
            ClassTimes = new List<ClassTime>();
        }

        public ClassTimesCollection(ClassTimesCollection classTimes)
        {
            ClassTimes = new List<ClassTime>(classTimes.ClassTimes);
        }

        public ClassTimesCollection(IEnumerable<ClassTime> classTimes)
        {
            ClassTimes = new List<ClassTime>(classTimes);
        }

        private List<ClassTime> ClassTimes { get; }

        public IEnumerable<ClassTime> IntersectWith(ClassTime classTime)
        {
            var intersections = new List<ClassTime>();
            foreach (ClassTime time in ClassTimes)
            {
                ClassTime? intersection = time.IntersectWith(classTime);
                if (intersection.HasValue)
                {
                    intersections.Add(intersection.Value);
                }
            }

            return intersections;
        }

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
            for (int i = ClassTimes.Count - 1; i >= 0; i--)
            {
                ClassTime? union = classTime.UnionIfOverlapsOrContinousWith(ClassTimes[i]);
                if (union.HasValue)
                {
                    ClassTimes.RemoveAt(i);
                    classTime = union.Value;
                }
            }

            ClassTimes.Add(classTime);
            Sort();
        }

        public void AddAll(IEnumerable<ClassTime> classTimes)
        {
            foreach (ClassTime classTime in classTimes)
            {
                Add(classTime);
            }
        }

        public void RemoveAll(IEnumerable<ClassTime> classTimes)
        {
            foreach (ClassTime classTime in classTimes)
            {
                Remove(classTime);
            }
        }

        public void Remove(ClassTime classTime)
        {
            for (int i = ClassTimes.Count - 1; i >= 0; i--)
            {
                IEnumerable<ClassTime> subtractResult = ClassTimes[i].Subtract(classTime);
                ClassTimes.RemoveAt(i);
                foreach (ClassTime subtractedTime in subtractResult)
                {
                    ClassTimes.Add(subtractedTime);
                }
            }

            Sort();
        }

        public ClassTimesCollection Clone() => new ClassTimesCollection(this);

        private void Sort()
        {
            ClassTimes.Sort((x, y) =>
            {
                if (x.Day < y.Day)
                {
                    return -1;
                }
                else if (x.Day == y.Day)
                {
                    return x.Start.CompareTo(y.Start);
                }
                else // x.Day < y.Day
                {
                    return 1;
                }
            });
        }

        object ICloneable.Clone() => Clone();
        public IEnumerator<ClassTime> GetEnumerator() => ((IEnumerable<ClassTime>)ClassTimes).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<ClassTime>)ClassTimes).GetEnumerator();
    }
}
