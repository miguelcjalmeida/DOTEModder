using Mod.HeroesRework.Skills;
using Modder.Common.Managers;
using Modder.Heroes.Entities;
using System.Linq;

namespace Mod.HeroesRework.Heroes
{
    public class MaxRework : IHeroRework
    {
        public string HeroName => "Max O'Kane";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var deadeye = new Headshot();
            var verbalAbuse = manager.SkillManager.Find("Verbal Abuse");
            hero.ReplaceSkill(verbalAbuse, deadeye);
            manager.SkillManager.Stored.Add(deadeye);
        }
    }
}
