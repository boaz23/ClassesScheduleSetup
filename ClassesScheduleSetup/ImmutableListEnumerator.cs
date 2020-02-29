using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassesScheduleSetup
{
    public class ImmutableListEnumerator
    {
        public static ImmutableListEnumerator<T> FromEnumerable<T>(IEnumerable<T> items)
        {
            return new ImmutableListEnumerator<T>(new List<T>(items));
        }
    }

    public class ImmutableListEnumerator<T> : IEnumerable<T>
    {
        private int index;
        private IList<T> list;

        public ImmutableListEnumerator(IList<T> list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            this.list = list;
            index = -1;
        }

        private ImmutableListEnumerator(IList<T> list, int index)
        {
            this.list = list;
            this.index = index;
        }

        public bool HasStarted => index >= 0;
        public bool HasEnded => index >= list.Count;

        public bool IsEmpty => list.Count == 0;

        public T Current
        {
            get
            {
                if (!HasStarted)
                {
                    throw new InvalidOperationException("Enumeration hasn't started.");
                }
                if (HasEnded)
                {
                    throw new InvalidOperationException("Enumeration has ended.");
                }

                return list[index];
            }
        }

        public ImmutableListEnumerator<T> MoveNext()
        {
            return new ImmutableListEnumerator<T>(list, index + 1);
        }

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
    }
}
