using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Entities.Item.Rarity;
using Modder.Entities.Item.SimulationDescriptor;
using Modder.Loader;

namespace Modder.Loaders.HeroItem
{
    public class HeroItemSimulationLoader : XmlLoader
    {
        private readonly IList<Entities.Item.HeroItem> _items;

        public HeroItemSimulationLoader(IList<Entities.Item.HeroItem> items)
        {
            _items = items;
        }
        
        public void PopulateFromAssets(string assetsPath) {
            var document = LoadDocument($"{assetsPath}/Simulation/SimulationDescriptors_ItemHero.xml");
            _items.ForEach(x => PopulateVariationDescriptors(x, document));
            _items.ForEach(PopulateDescriptorsRelationship);
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

        private void PopulateDescriptorsRelationship(Entities.Item.HeroItem item)
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