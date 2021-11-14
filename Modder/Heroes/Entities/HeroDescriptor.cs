using Modder.HeroItems.Entities.SimulationDescriptor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Heroes.Entities
{
    public class HeroDescriptor
    {
        public IList<ModifierDescriptor> Modifiers { get; set; }

        public string GetIdentifier(string heroName, int level) {
            if (GetType(level) == HeroDescriptorType.Hero) return $"Hero_{heroName}";
            return $"Hero_{heroName}_LVL{level}";
        }

        public HeroDescriptorType GetType(int level)
        {
            if (level <= 1) return HeroDescriptorType.Hero;
            return HeroDescriptorType.HeroLevel;
        }
    }
}
