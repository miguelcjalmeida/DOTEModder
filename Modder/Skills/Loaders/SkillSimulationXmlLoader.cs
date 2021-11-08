using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using Modder.Common;
using Modder.Common.Loaders;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Skills.Entities;

namespace Modder.Skills.Loaders
{
    public class SkillSimulationXmlLoader : XmlLoader
    {
        private readonly IList<Skill> _skills;

        public SkillSimulationXmlLoader(IList<Skill> skills)
        {
            _skills = skills;
        }

        public void PopulateFromAssets(string assetsPath)
        {
            var document = LoadDocument($"{assetsPath}/Simulation/SimulationDescriptors_Skill.xml");
            _skills.ForEach(skill =>
                skill.Levels.ForEach(level => PopulateLevelDescriptors(skill, level, document)));
        }

        private void PopulateLevelDescriptors(Skill skill, SkillLevel level, XmlDocument document)
        {
            level.Descriptors = new Collection<SkillDescriptor>();
            PopulateSelfLevelDescriptor(skill, level, document);
            PopulateTargetLevelDescriptor(skill, level, document);
        }

        private void PopulateSelfLevelDescriptor(Skill skill, SkillLevel level, XmlDocument document)
            => PopulateDescriptor(skill, level, document, false);

        private void PopulateTargetLevelDescriptor(Skill skill, SkillLevel level, XmlDocument document)
            => PopulateDescriptor(skill, level, document, true);

        private void PopulateDescriptor(Skill skill, SkillLevel level, XmlDocument document, bool applyToTarget)
        {
            var suffix = applyToTarget ? "_Target" : "";
            var xpath = $"Datatable/SimulationDescriptor[@Name='{level.GetIdentifier(skill)}{suffix}']";
            var node = document.SelectSingleNode(xpath);
            if (node == null) return;
            level.Descriptors.Add(new SkillDescriptor
            {
                Modifiers = CreateModifiers(node),
                AppliesToTarget = applyToTarget
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
                    Path = x.Attributes["Path"]?.Value
                })
                .ToList();
        }
    }
}