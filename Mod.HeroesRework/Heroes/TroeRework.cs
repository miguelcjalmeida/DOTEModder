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
    public class TroeRework : IHeroRework
    {
        public string HeroName => "Troe Pekenyo";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var greatswordAbuser = new GreatswordAbuser();
            hero.LearnSkillAt(greatswordAbuser, 1);
            manager.SkillManager.Stored.Add(greatswordAbuser);
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
            if (IsNotPowerOrCooldown(modifier)) return;
            modifier.Value *= (float)Math.Round(1f/1.75f, 0); 
        }

        private static bool IsNotPowerOrCooldown(ModifierDescriptor modifier)
        {
            return modifier.TargetProperty != TargetProperty.AttackPower && 
                modifier.TargetProperty != TargetProperty.AttackCooldown;
        }
    }
}
