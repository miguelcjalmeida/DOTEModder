using System;
using System.Collections.Generic;
using System.Linq;

namespace Modder
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }

        public static IList<T> Clone<T>(this IList<T> items) where T : ICloneable
        {
            var newItems = new List<T>();
            foreach (var item in items)
                newItems.Add((T)item.Clone());
            return newItems;
        }
    }
}