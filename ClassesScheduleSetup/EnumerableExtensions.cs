using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesScheduleSetup
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source == null || !source.Any();
        }

        public static void AddAll<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (!IsNullOrEmpty(items))
            {
                foreach (T item in items)
                {
                    collection.Add(item);
                }
            }
        }

        public static IEnumerable<TSource> AsEnumerable<TSource>(TSource item)
        {
            return Enumerable.Empty<TSource>().Append(item);
        }
    }
}
