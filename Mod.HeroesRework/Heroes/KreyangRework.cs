using Mod.HeroesRework.Skills;
using Modder.Common.Managers;
using Modder.Heroes.Entities;
using Modder.HeroItems.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.HeroesRework.Heroes
{
    public class KreyangRework : IHeroRework
    {
        public string HeroName => "Kreyang";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            var frostArmor = new FrostArmor();
            var iceBlock = new IceBlock();
            var defrosting = new Defrosting();
            var holdTheLine = manager.SkillManager.Find("Hold the Line");

            hero.ReplaceEquipment(EquipmentName.Armor, EquipmentName.Weapon, WeaponType.Weapon_Spear);

            hero.LearnSkillEvenly(frostArmor);
            hero.LearnSkillEvenly(defrosting);
            hero.LearnSkillAt(iceBlock, 2);
            hero.UnlearnSkill(holdTheLine);

            manager.SkillManager.Stored.Add(frostArmor);
            manager.SkillManager.Stored.Add(defrosting);
            manager.SkillManager.Stored.Add(iceBlock);
        }
    }
}
