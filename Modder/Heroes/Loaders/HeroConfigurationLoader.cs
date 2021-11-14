using Modder.Common.Loaders;
using Modder.Heroes.Entities;
using Modder.HeroItems.Entities;
using Modder.Localizations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Modder.Heroes.Loaders
{
    public class HeroConfigurationLoader : XmlLoader
    {
        private readonly LocalizationProvider _localizationProvider;

        public HeroConfigurationLoader(LocalizationProvider localizationProvider)
        {
            _localizationProvider = localizationProvider;
        }

        public IList<Hero> LoadFromAssets(string assetsPath)
        {
            var heroDoc = LoadDocument($"{assetsPath}/Configuration/HeroConfigs.xml");
            var nodes = heroDoc.SelectNodes("Datatable/HeroConfig");
            return nodes.AsQuery()
                .Select(CreateHero)
                .ToList();
        }

        private Hero CreateHero(XmlNode heroConfig)
        {
            var hero = new Hero();
            hero.Identifier = heroConfig.Attribute("Name");
            hero.RecruitmentFoodCost = heroConfig.Attribute<int>("RecruitmentFoodCost");
            hero.AITargetType = heroConfig.Attribute<AITargetType>("AITargetType");
            hero.AttackType = heroConfig.Attribute<AttackType>("AttackType");
            hero.Archetype = _localizationProvider.Get(heroConfig.Attribute("Archetype"));
            hero.UnlockLevelCount = heroConfig.Attribute<int>("UnlockLevelCount");
            hero.Faction = heroConfig.Attribute<Faction>("Faction");
            hero.IntroDialogs = heroConfig.Select("IntroDialogs/Dialog", CreateDialog);
            hero.EquipmentSlots = heroConfig.Select("EquipmentSlots/EquipmentSlot", CreateEquipmentSlot);
            return hero;
        }

        private Dialog CreateDialog(XmlNode dialogConfig)
        {
            return new Dialog()
            {
                Name = dialogConfig.Attribute("Name"),
                Text = _localizationProvider.Get(dialogConfig.Attribute("Text")),
            };
        }

        private EquipmentSlot CreateEquipmentSlot(XmlNode equipConfig)
        {
            return new EquipmentSlot
            {
                Name = equipConfig.Attribute("Name"),
                Type = equipConfig.Attribute<WeaponType?>("Type"),
            };
        }
    }
}