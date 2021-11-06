using Modder;
using Modder.Entities.HeroItem;
using Modder.Manager;
using Modder.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.WeaponDiverseAttributes
{
    public class DiverseAttributesMod : IMod
    {
        private const int VERSIONS_PER_ITEM = 10;
        private readonly ItemForger forger;
        private EntitiesManager manager;

        public DiverseAttributesMod()
        {
            forger = new ItemForger();            
        }

        public void Apply(EntitiesManager manager)
        {
            this.manager = manager;
            var allItems = new List<HeroItem>();

            manager.HeroItemManager.Stored.ForEach(item =>
            {
                var newItems = ForgeNewVersionsOf(item);
                allItems.AddRange(newItems);
            });

            manager.HeroItemManager.Stored = allItems;
        }

        private IList<HeroItem> ForgeNewVersionsOf(HeroItem item)
        {
            var forgedItems = new List<HeroItem>();

            for (var i=0; i<VERSIONS_PER_ITEM; i++)
            {
                var forgedItem = forger.Forge(item);
                forgedItems.Add(forgedItem);

                var oldName = item.Name;
                var newName = GetUniqueName(oldName, i);
                forgedItem.Name = newName;

                AddToTheShips(oldName, newName);
            }

            return forgedItems;
        }

        private string GetUniqueName(string oldName, int count)
        {
            if (count == 0) return oldName;
            return $"{oldName}_{count}";
        }

        private void AddToTheShips(string oldName, string newName)
        {
            this.manager.ShipManager.Stored.ForEach(ship =>
            {
                if (!ship.UnavailableItems.Contains(oldName)) return;
                ship.UnavailableItems.Add(newName);
            });
        }
    }
}
