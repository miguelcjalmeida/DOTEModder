using Modder;
using Modder.Entities.HeroItem;
using Modder.Entities.HeroItem.SimulationDescriptor;
using Modder.Entities.Ship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.WeaponDiverseAttributes
{
    public class ItemForger
    {
        public HeroItem Forge(HeroItem baseItem)
        {
            HeroItem newItem = baseItem.Clone();

            for (var i = 0; i < newItem.Descriptors.Count; i++)
            {
                var descriptor = newItem.Descriptors[i];
                ForgeNewAttributes(newItem, descriptor);
            }

            return newItem;
        }

        private void ForgeNewAttributes(HeroItem newItem, HeroItemDescriptor descriptor)
        {
            var itemLevel = ModRandom.Next(0, 2) + descriptor.Rarity.Level;
            var engine = new LevelUpEngine(descriptor.Modifiers);

            if (!engine.CanLevelUp()) return;

            for (var i = 0; i < itemLevel; )
            {
                if (engine.TryToLevelUp()) i++;
            }

            descriptor.For(TargetProperty.Cost, x => x.Value += itemLevel * 8);
            descriptor.Add(TargetProperty.SellingCost, Operation.Subtraction, itemLevel * 4);
        }
    }
}
