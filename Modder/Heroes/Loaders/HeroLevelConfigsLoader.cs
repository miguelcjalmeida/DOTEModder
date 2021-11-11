using Modder.Common;
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
    public class HeroLevelConfigsLoader : XmlLoader
    {
        private readonly IList<Hero> heroes;

        public HeroLevelConfigsLoader(IList<Hero> heroes)
        {
            this.heroes = heroes;
        }

        public void PopulateFromAssets(string assetsPath)
        {
            var levelDoc = LoadDocument($"{assetsPath}/Configuration/HeroLevelConfigs.xml");
            heroes.ForEach(hero => 
            {
                hero.HeroLevels = levelDoc.Select($"Datatable/HeroLevelConfig[starts-with(Name,'{hero.Identifier}')]", CreateHeroLevel);
            });
        }

        private HeroLevel CreateHeroLevel(XmlNode heroConfig)
        {
            var level = new HeroLevel();
            level.FoodCost = heroConfig.Attribute<int>("FoodCost");
            level.Level = XmlTranslation.ValueAs<int>(heroConfig.Attribute("Name").Split("_LVL")[1]);
            level.Skills = heroConfig.Select("Skills/Skill", CreateSkill);
            return level;
        }

        private string CreateSkill(XmlNode skillConfig)
        {
            return skillConfig.InnerText;
        }
    }
}