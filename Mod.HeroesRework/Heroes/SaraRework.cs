using Mod.HeroesRework.Skills;
using Modder.Common.Managers;
using Modder.Heroes.Entities;

namespace Mod.HeroesRework.Heroes
{
    public class SaraRework : IHeroRework
    {
        public string HeroName => "Sara Numas";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var assassinDagger = new AssassinDagger();
            hero.LearnSkillAt(assassinDagger, 1);
            manager.SkillManager.Stored.Add(assassinDagger);
        }
    }
}
