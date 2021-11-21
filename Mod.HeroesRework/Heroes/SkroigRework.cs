using Mod.HeroesRework.Skills;
using Modder.Common.Managers;
using Modder.Heroes.Entities;

namespace Mod.HeroesRework.Heroes
{
    public class SkroigRework : IHeroRework
    {
        public string HeroName => "Skroig";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var makeSomeFood = new MakeSomeFood();
            var viciousDuelist = new ViciousDuelist();
            var lastSupper = manager.SkillManager.Find("Last Supper");
            hero.ReplaceSkill(lastSupper, makeSomeFood);
            hero.LearnSkillAt(viciousDuelist, 1);
            manager.SkillManager.Stored.Add(makeSomeFood);
            manager.SkillManager.Stored.Add(viciousDuelist);
        }
    }
}
