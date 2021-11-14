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
    public class GolgyRework : IHeroRework
    {
        public string HeroName => "Golgy Phurtiver";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            hero.ReplaceEquipment(EquipmentName.Armor, EquipmentName.Special);

            var crawler = manager.SkillManager.Find("Crawler");
            var showYourself = new ShowYourself();
            var livingBug = new LivingBug();

            hero.LearnSkillAt(livingBug, 3);
            hero.ReplaceSkill(crawler, showYourself);
            manager.SkillManager.Stored.Add(livingBug);
            manager.SkillManager.Stored.Add(showYourself);

            DecreaseMaxHealth(hero);
        }

        private static void DecreaseMaxHealth(Hero hero)
        {
            hero.Levels.ForEach(level =>
            {
                if (level.Level <= 2) return;

                level.Descriptors
                    .SelectMany(x => x.Modifiers)
                    .Where(x => x.TargetProperty == TargetProperty.MaxHealth)
                    .ForEach(x => x.Value /= 2);
            });
        }
    }
}
