using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Entities.HeroItem;
using Modder.Entities.HeroItem.Rarity;
using Modder.Entities.HeroItem.SimulationDescriptor;

namespace Modder.Loaders.HeroItems
{
    public class HeroItemConfigurationLoader : XmlLoader
    {
        public IList<HeroItem> LoadFromAssets(string assetsPath)
        {
            var heroItemsDoc = LoadDocument($"{assetsPath}/Configuration/ItemHeroConfigs.xml");
            var itemsNodes = heroItemsDoc.SelectNodes("Datatable/ItemHeroConfig");
            return itemsNodes.AsQuery()
                .Select(CreateHeroItemFromConfiguration)
                .ToList();
        }
        
        private static HeroItem CreateHeroItemFromConfiguration(XmlNode itemHeroConfig)
        {
            var depthRange = itemHeroConfig.SelectSingleNode("DepthRanges/DepthRange");
            var category = itemHeroConfig.SelectSingleNode("Category");
            var skills = itemHeroConfig.SelectNodes("Skills/Skill");

            return new HeroItem
            {
                Name = itemHeroConfig.Attributes["Name"].Value,
                AttackType = itemHeroConfig.Attributes["AttackType"]?.Value.ParseToEnum<AttackType>(),
                DropCriteria = GetDropCriteriaFromDepthRange(depthRange),
                Category = category.Attributes["Name"].Value.ParseToEnum<ItemCategory>(),
                WeaponType = category.Attributes["Type"]?.Value.ParseToEnum<WeaponType>(),
                SkillIDs = skills.AsQuery().Select(x => x.InnerText).ToList(),
                Descriptors = itemHeroConfig.SelectNodes("Rarities/Rarity")
                    .AsQuery()
                    .Select(x => new HeroItemDescriptorFromXml
                    {
                        Rarity = new ItemRarity
                        {
                            Name = x.Attributes["Name"].Value.ParseToEnum<RarityName>(),
                            DropCriteria =
                                GetDropCriteriaFromDepthRange(x.SelectSingleNode("DepthRanges/DepthRange"))
                        }
                    })
                    .Cast<HeroItemDescriptor>()
                    .ToList(),
            };
        }
        
        private static DropCriteria GetDropCriteriaFromDepthRange(XmlNode depthRange)
        {
            var probabilityWeight = depthRange.SelectSingleNode("ProbabilityWeight");
            
            return new DropCriteria
            {
                MinLevel = Convert.ToInt32(depthRange.Attributes["LevelMin"].Value),
                MaxLevel = Convert.ToInt32(depthRange.Attributes["LevelMax"].Value),
                ProbabilityWeight = Convert.ToInt32(probabilityWeight.Attributes["StartValue"].Value)
            };
        }
    }
}