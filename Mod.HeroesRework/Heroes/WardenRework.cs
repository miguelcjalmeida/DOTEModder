using Mod.HeroesRework.Skills;
using Modder.Common.Managers;
using Modder.Heroes.Entities;

namespace Mod.HeroesRework.Heroes
{
    public class WardenRework : IHeroRework
    {
        public string HeroName => "Warden Mormish";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var supervisor = new Supervisor();
            var justDoIt = new JustDoIt();
            var operate = manager.SkillManager.Find("Operate");
            var repair = manager.SkillManager.Find("Repair");
            hero.ReplaceSkill(operate, supervisor);
            hero.ReplaceSkill(repair, justDoIt);
            manager.SkillManager.Stored.Add(supervisor);
            manager.SkillManager.Stored.Add(justDoIt);
        }
    }
}
