using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Entities.HeroItem;
using Modder.Entities.HeroItem.Rarity;
using Modder.Entities.HeroItem.SimulationDescriptor;

namespace Modder.Loaders.HeroItems
{
    public class HeroItemSimulationLoader : XmlLoader
    {
        private readonly IList<HeroItem> _items;

        public HeroItemSimulationLoader(IList<HeroItem> items)
        {
            _items = items;
        }
        
        public void PopulateFromAssets(string assetsPath) {
            var document = LoadDocument($"{assetsPath}/Simulation/SimulationDescriptors_ItemHero.xml");
            _items.ForEach(x => PopulateVariationDescriptors(x, document));
            _items.ForEach(PopulateDescriptorsRelationship);
        }
        
        private static void PopulateVariationDescriptors(HeroItem item, XmlDocument simulationDoc)
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

        private void PopulateDescriptorsRelationship(HeroItem item)
        {
            var allDescriptors = _items
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
    }
}