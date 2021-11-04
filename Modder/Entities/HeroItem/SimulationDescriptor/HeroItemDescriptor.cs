using System;
using System.Collections.Generic;
using System.Linq;
using Modder.Entities.HeroItem.Rarity;

namespace Modder.Entities.HeroItem.SimulationDescriptor
{
    public class HeroItemDescriptor : ICloneable
    {
        public ItemRarity Rarity { get; set; }
        public HeroItemDescriptor Parent { get; set; }
        public IList<ModifierDescriptor> Modifiers { get; set; }
   
        public string GetName(string heroItemName) => $"ItemHero_{heroItemName}{Rarity.Suffix}";
        
        public string GetType(string heroItemName) => Parent?.GetName(heroItemName) ?? "ItemHero";

        public object Clone()
        {
            var descriptor = new HeroItemDescriptor();
            descriptor.Rarity = Rarity;
            descriptor.Parent = (HeroItemDescriptor)(Parent?.Clone());
            descriptor.Modifiers = Modifiers?.Clone();
            return descriptor;
        }

        public void For(TargetProperty property, Action<ModifierDescriptor> modifierAction)
        {
            var modifier = Modifiers.Where(x => x.TargetProperty == property).FirstOrDefault();
            if (modifier == null) return;
            modifierAction(modifier);
        }

        public void Add(TargetProperty property, Operation operation, float value)
        {
            var modifier = new ModifierDescriptor();
            modifier.TargetProperty = property;
            modifier.Operation = operation;
            modifier.Value = value;
            Modifiers.Add(modifier);
        }
    }
}