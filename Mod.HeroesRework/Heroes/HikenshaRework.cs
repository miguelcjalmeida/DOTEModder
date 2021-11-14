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
    public class HikenshaRework : IHeroRework
    {
        public string HeroName => "Hikensha";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var terror = new Terror();

            for (var i = 1; i <= 9; i++)
                hero.LearnSkillAt(terror, i);

            manager.SkillManager.Stored.Add(terror);
        }
    }
}
