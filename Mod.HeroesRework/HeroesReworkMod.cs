using Mod.HeroesRework.Heroes;
using Modder;
using Modder.Common;
using Modder.Common.Managers;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mod.HeroesRework
{
    public class HeroesReworkMod : IMod
    {
        public void Apply(EntitiesManager manager)
        {
            DisableFoodCosts(manager);

            var reworks = new List<IHeroRework>()
            {
                new MaxRework(), new MiziRework(), new GolgyRework(), new HikenshaRework(), new KreyangRework(),
                new TroeRework(), new SkroigRework()
            };

            reworks.ForEach(rework =>
            {
                var hero = manager.HeroManager.Stored.FirstOrDefault(x => x.Title.Is(rework.HeroName));
                if (hero == null) return;
                rework.Apply(hero, manager);
            });
        }

        private static void DisableFoodCosts(EntitiesManager manager)
        {
            manager.HeroManager.Stored.ForEach(x =>
                            x.Levels.ForEach(l =>
                                l.FoodCost = 0));
        }
    }
}
