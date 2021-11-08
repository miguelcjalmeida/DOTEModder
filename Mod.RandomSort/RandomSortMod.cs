using Modder;
using Modder.Common;
using Modder.Common.Managers;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mod.RandomSort
{
    public class RandomSortMod : IMod
    {
        public void Apply(EntitiesManager manager)
        {
            Randomize(manager.HeroItemManager.Stored);
            Randomize(manager.SkillManager.Stored);
        }

        private void Randomize<T>(IList<T> items)
        {
            var sortedItems = new List<T>(items);

            items.Clear();

            for (int i = 0, size=sortedItems.Count; i < size; i++)
            {
                var min = 0;
                var max = sortedItems.Count - 1;
                var nextIndex = ModRandom.Next(min, max);
                items.Add(sortedItems[nextIndex]);
                sortedItems.RemoveAt(nextIndex);
            }
        }
    }
}
