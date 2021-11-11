using Modder.HeroItems.Entities.SimulationDescriptor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Heroes.Entities
{
    public class HeroDescriptor
    {
        public int Level { get; set; }

        public HeroDescriptorType Type { 
            get {
                if (Level == 0) return HeroDescriptorType.Hero;
                return HeroDescriptorType.HeroLevel;
            } 
        }

        public IList<ModifierDescriptor> Modifiers { get; set; }

        public string GetName(string heroName) {
            if (Type == HeroDescriptorType.Hero) return $"Hero_{heroName}";
            return $"Hero_{heroName}_LVL{Level}";
        }
    }
}
