using System.Collections.Generic;
using Modder.Entities.Item.Rarity;

namespace Modder.Entities.Item.SimulationDescriptor
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