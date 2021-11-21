using Mod.HeroesRework.Skills;
using Modder.Common;
using Modder.Common.Managers;
using Modder.Heroes.Entities;
using Modder.HeroItems.Entities.SimulationDescriptor;
using System.Linq;

namespace Mod.HeroesRework.Heroes
{
    public class MaxRework : IHeroRework
    {
        public string HeroName => "Max O'Kane";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var headshot = new Headshot();
            var verbalAbuse = manager.SkillManager.Find("Verbal Abuse");
            hero.UnlearnSkill(verbalAbuse);
            hero.LearnSkillEvenly(headshot, 2);
            manager.SkillManager.Stored.Add(headshot);
        }
    }
}
