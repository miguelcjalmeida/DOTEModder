using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Entities.Item;
using Modder.Entities.Item.Rarity;
using Modder.Entities.Item.SimulationDescriptor;
using Modder.Entities.Localization;
using Modder.Loader;

namespace Modder.Loaders.HeroItem
{
    public class HeroItemLoader : Loader<Entities.Item.HeroItem>
    {
        public IList<Entities.Item.HeroItem> LoadFromAssets(string assetsPath)
        {
            var heroItemsDoc = LoadDocument($"{assetsPath}/Configuration/ItemHeroConfigs.xml");
            var englishDoc = LoadDocument($"{assetsPath}/Localization/english/ED_Localization_Locales.xml");
            var frenchDoc = LoadDocument($"{assetsPath}/Localization/french/ED_Localization_Locales.xml");
            var germanDoc = LoadDocument($"{assetsPath}/Localization/german/ED_Localization_Locales.xml");
            var guiDoc = LoadDocument($"{assetsPath}/Gui/GuiElements_ItemHero.xml");
            var simulationDoc = LoadDocument($"{assetsPath}/Simulation/SimulationDescriptors_ItemHero.xml");
            
            var itemsNodes = heroItemsDoc.SelectNodes("Datatable/ItemHeroConfig");
            var results = new List<Entities.Item.HeroItem>();
            
            foreach (XmlNode heroItemConfig in itemsNodes)
            {
                var item = CreateHeroItemFromConfiguration(heroItemConfig);
                PopulateHeroItemLocalization(item, englishDoc, frenchDoc, germanDoc);
                PopulateIcon(item, guiDoc);
                PopulateVariationDescriptors(item, simulationDoc);
                results.Add(item);
            }

            foreach (var item in results)
            {
                PopulateDescriptorsRelationship(item, results);
            }

            return results;
        }

        private static XmlDocument LoadDocument(string assetsPath)
        {
            var heroItemsDoc = new XmlDocument();
            heroItemsDoc.Load(assetsPath);
            return heroItemsDoc;
        }

        private static Entities.Item.HeroItem CreateHeroItemFromConfiguration(XmlNode itemHeroConfig)
        {
            var depthRange = itemHeroConfig.SelectSingleNode("DepthRanges/DepthRange");
            var category = itemHeroConfig.SelectSingleNode("Category");
            var skills = itemHeroConfig.SelectNodes("Skills/Skill");

            return new Entities.Item.HeroItem
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

        private static void PopulateHeroItemLocalization(Entities.Item.HeroItem item, XmlDocument englishDoc, XmlDocument frenchDoc, XmlDocument germanDoc)
        {
            item.Title = new Description
            {
                English = GetHeroItemTitleLocalization(item, englishDoc),
                French = GetHeroItemTitleLocalization(item, frenchDoc),
                German = GetHeroItemTitleLocalization(item, germanDoc)
            };
            
            item.Description = new Description()
            {
                English = GetHeroItemDescriptionLocalization(item, englishDoc),
                French = GetHeroItemDescriptionLocalization(item, frenchDoc),
                German = GetHeroItemDescriptionLocalization(item, germanDoc)
            };
        }

        private static void PopulateIcon(Entities.Item.HeroItem item, XmlDocument guiDoc)
        {
            var icon = guiDoc.SelectSingleNode($"Datatable/GuiElement[@Name='{item.Name}']/Icons/Icon");
            item.IconPath = icon.Attributes["Path"].Value;
        }

        private static void PopulateVariationDescriptors(Entities.Item.HeroItem item, XmlDocument simulationDoc)
        {
            item.Descriptors.Cast<HeroItemDescriptorFromXml>().ForEach(descriptor =>
            {
                var raritySuffix = descriptor.Rarity.Name == RarityName.Common ? "" : $"_{descriptor.Rarity.Name}";
                var name = $"ItemHero_{item.Name}{raritySuffix}";
                var node = simulationDoc.SelectSingleNode($"Datatable/SimulationDescriptor[@Name='{name}']");

                descriptor.Type = name;
                descriptor.ParentType = node?.Attributes["Type"].Value;
                descriptor.Modifiers = CreateSimulationDescriptors(node);
            });
        }

        private static void PopulateDescriptorsRelationship(Entities.Item.HeroItem item, IEnumerable<Entities.Item.HeroItem> allItems)
        {
            var allDescriptors = allItems
                .SelectMany(x => x.Descriptors)
                .Cast<HeroItemDescriptorFromXml>();
            
            item.Descriptors.Cast<HeroItemDescriptorFromXml>().ForEach(variation =>
            {
                var parentType = variation.ParentType;
                variation.Parent = allDescriptors.FirstOrDefault(x => x.Type == parentType);
            });
        }

        private static IList<ModifierDescriptor> CreateSimulationDescriptors(XmlNode simulationNode)
        {
            var descriptors = simulationNode.SelectNodes("SimulationModifierDescriptors/SimulationModifierDescriptor");
            
            return descriptors.AsQuery()
                .Select(x => new ModifierDescriptor
                {
                    TargetProperty = x.Attributes["TargetProperty"].Value.ParseToEnum<TargetProperty>(),
                    Operation = x.Attributes["Operation"].Value.ParseToEnum<Operation>(),
                    Value =  Convert.ToSingle(x.Attributes["Value"].Value),
                })
                .ToList();
        }

        private static string GetHeroItemTitleLocalization(Entities.Item.HeroItem item, XmlDocument localizationDoc)
            => localizationDoc.SelectSingleNode($"Datatable/LocalizationPair[@Name='%Item_{item.Name}']").InnerText;
        
        private static string GetHeroItemDescriptionLocalization(Entities.Item.HeroItem item, XmlDocument localizationDoc)
            => localizationDoc.SelectSingleNode($"Datatable/LocalizationPair[@Name='%Item_{item.Name}_Description']").InnerText;
        
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