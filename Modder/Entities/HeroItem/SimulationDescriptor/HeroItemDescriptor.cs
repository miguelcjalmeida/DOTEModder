using System.Collections.Generic;
using Modder.Entities.HeroItem.Rarity;

namespace Modder.Entities.HeroItem.SimulationDescriptor
{
    public class HeroItemDescriptor
    {
        public ItemRarity Rarity { get; set; }
        public HeroItemDescriptor Parent { get; set; }
        public IList<ModifierDescriptor> Modifiers { get; set; }
        
        public string GetName(string heroItemName) => $"ItemHero_{heroItemName}{Rarity.Suffix}";
        
        public string GetType(string heroItemName) => Parent?.GetName(heroItemName) ?? "ItemHero";
    }
}