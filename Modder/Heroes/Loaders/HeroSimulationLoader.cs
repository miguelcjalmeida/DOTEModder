using Modder.Common;
using Modder.Common.Loaders;
using Modder.Heroes.Entities;
using Modder.HeroItems.Entities;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;

namespace Modder.Heroes.Loaders
{
    public class HeroSimulationLoader : XmlLoader
    {
        private readonly IList<Hero> _heroes;

        public HeroSimulationLoader(IList<Hero> heroes)
        {
            _heroes = heroes;
        }

        public void PopulateFromAssets(string assetsPath)
        {
            var document = LoadDocument($"{assetsPath}/Simulation/SimulationDescriptors_Hero.xml");
            _heroes.ForEach(hero =>
                hero.Levels.ForEach(level => PopulateLevelDescriptors(hero, level, document)));
        }

        private void PopulateLevelDescriptors(Hero hero, HeroLevel level, XmlDocument document)
        {
            level.Descriptors = new Collection<HeroDescriptor>();
            PopulateDescriptor(hero, level, document);
        }


        private void PopulateDescriptor(Hero hero, HeroLevel level, XmlDocument document)
        {
            var xpath = $"Datatable/SimulationDescriptor[@Name='{level.GetIdentifier(hero.Name)}']";
            var node = document.SelectSingleNode(xpath);
            if (node == null) return;
            level.Descriptors.Add(new HeroDescriptor
            {
                Modifiers = CreateModifiers(node),
            });
        }

        private static IList<ModifierDescriptor> CreateModifiers(XmlNode simulationNode)
        {
            var descriptors = simulationNode.SelectNodes("SimulationModifierDescriptors/SimulationModifierDescriptor");

            return descriptors.AsQuery()
                .Select(x => new ModifierDescriptor
                {
                    TargetProperty = x.Attributes["TargetProperty"].Value.ParseToEnum<TargetProperty>(),
                    Operation = x.Attributes["Operation"].Value.ParseToEnum<Operation>(),
                    Value = (float)Convert.ToDouble(x.Attributes["Value"].Value),
                    Path = XmlTranslation.ValueAs<Path?>(x.Attributes["Path"]?.Value),
                })
                .ToList();
        }
    }
}