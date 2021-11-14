using Mod.HeroesRework.Skills;
using Modder.Common;
using Modder.Common.Managers;
using Modder.Heroes.Entities;
using Modder.HeroItems.Entities.SimulationDescriptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.HeroesRework.Heroes
{
    public class MiziRework : IHeroRework
    {
        public string HeroName => "Mizi Kurtiz";

        public void Apply(Hero hero, EntitiesManager manager)
        {
            ReworkBadCompany(manager);
            var dangerJunkie = manager.SkillManager.Find("Danger Junkie");
            var bloodThirst = new BloodThirst();
            hero.ReplaceSkill(dangerJunkie, bloodThirst);
            manager.SkillManager.Stored.Add(bloodThirst);
        }

        private static void ReworkBadCompany(EntitiesManager manager)
        {
            var badCompany = manager.SkillManager.Find("Bad Company");

            var descriptor = badCompany.Levels.First().Descriptors.First();
            descriptor.AppliesToTarget = false;

            var modifiers = descriptor.Modifiers;
            modifiers.Clear();

            var powerPerAllyBuff = new ModifierDescriptor
            {
                TargetProperty = TargetProperty.AttackPowerBonusPerHeroInRoomMinusOne,
                Operation = Operation.Addition,
                Value = 20,
                Path = Path.CurrentHero
            };

            var alliesPowerDebuff = new ModifierDescriptor
            {
                TargetProperty = TargetProperty.AttackPower,
                Operation = Operation.Subtraction,
                Value = 15,
                Path = Path.HeroesInRoom
            };

            var selfPowerBuff = new ModifierDescriptor
            {
                TargetProperty = TargetProperty.AttackPower,
                Operation = Operation.Addition,
                Value = 15,
                Path = Path.CurrentHero
            };

            var powerPerEnemyBuff = new ModifierDescriptor
            {
                TargetProperty = TargetProperty.AttackPowerBonusPerMobInRoom,
                Operation = Operation.Addition,
                Value = 3,
                Path = Path.CurrentHero
            };

            var maxPowerPerEnemyBuff = new ModifierDescriptor
            {
                TargetProperty = TargetProperty.AttackPowerBonusFromMobsMax,
                Operation = Operation.Addition,
                Value = 60,
                Path = Path.CurrentHero
            };

            var powerBuff = new ModifierDescriptor
            {

                TargetProperty = TargetProperty.AttackPower,
                Operation = Operation.Percent,
                Value = .15f,
                Path = Path.CurrentHero,
            };

            modifiers.Add(powerPerAllyBuff);
            modifiers.Add(alliesPowerDebuff);
            modifiers.Add(selfPowerBuff);
            modifiers.Add(powerPerEnemyBuff);
            modifiers.Add(maxPowerPerEnemyBuff);
            modifiers.Add(powerBuff);

            badCompany.Description.English = "Draws power from all living sources, willing or not";
            badCompany.Description.French = "Tire son pouvoir de toutes les sources vivantes, qu'il le veuille ou non";
            badCompany.Description.German = "Zieht Kraft aus allen lebenden Quellen, ob gewollt oder nicht";
        }
    }
}
