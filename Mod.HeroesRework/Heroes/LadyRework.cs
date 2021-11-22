using Mod.HeroesRework.Skills;
using Modder.Common;
using Modder.Common.Managers;
using Modder.Heroes.Entities;
using Modder.HeroItems.Entities;
using Modder.HeroItems.Entities.SimulationDescriptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.HeroesRework.Heroes
{
    public class LadyRework : IHeroRework
    {
        public string HeroName => "Lady Joleri Tulak";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var extraEnergyCell = new ExtraEnergyCell();
            hero.LearnSkillAt(extraEnergyCell, 1);
            manager.SkillManager.Stored.Add(extraEnergyCell);
            BalanceAttributes(hero);
        }

        private void BalanceAttributes(Hero hero)
        {
            hero.Levels.ForEach(level => 
                level.Descriptors.ForEach(descriptor => 
                    descriptor.Modifiers.ForEach(modifier => BalanceAttribute(modifier))));
        }

        private void BalanceAttribute(ModifierDescriptor modifier)
        {
            if (IsNotMaxHealth(modifier)) return;
            modifier.Value = (float)Math.Round(modifier.Value * (1f / 1.2f), 0); 
        }

        private static bool IsNotMaxHealth(ModifierDescriptor modifier)
        {
            return modifier.TargetProperty != TargetProperty.MaxHealth;
        }
    }
}
