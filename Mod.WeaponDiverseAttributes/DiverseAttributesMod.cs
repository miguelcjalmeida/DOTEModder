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

        public DiverseAttributesMod()
        {
            forger = new ItemForger();            
        }

        public void Apply(EntitiesManager manager)
        {
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

                var nameSuffix = i == 0 ? "" : $"{i}";
                forgedItem.Name = $"{item.Name}{nameSuffix}";
            }

            return forgedItems;
        }
    }
}
