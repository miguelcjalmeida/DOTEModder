using Mod.HeroesRework.Skills;
using Modder.Common.Managers;
using Modder.Heroes.Entities;

namespace Mod.HeroesRework.Heroes
{
    public class KenRework : IHeroRework
    {
        public string HeroName => "Ken Massoqui";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var tasteForPain = new TasteForPain();
            hero.LearnSkillAt(tasteForPain, 1);
            manager.SkillManager.Stored.Add(tasteForPain);
        }
    }
}
