using System;
using System.Collections.Generic;
using System.Linq;

namespace Modder.Common
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }

        public static void ForEach<T>(this IList<T> items, Action<T, int> action)
        {
            for (var i = 0; i< items.Count; i++)
                action(items[i], i);
        }

        public static IList<T> Clone<T>(this IList<T> items) where T : ICloneable
        {
            var newItems = new List<T>();
            foreach (var item in items)
                newItems.Add((T)item.Clone());
            return newItems;
        }

        public static bool Remove<T>(this IList<T> items, Func<T, bool> expression)
        {
            var hasRemoved = false;
            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                if (!expression(item)) continue;
                items.RemoveAt(i);
                i--;
                hasRemoved = true;
            }
            return hasRemoved;
        }
    }
}