using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using Modder.Entities.Item.SimulationDescriptor;
using Modder.Entities.Skill;
using Modder.Loader;

namespace Modder.Loaders.Skill
{
    public class SkillSimulationLoader : Loader
    {
        private readonly IList<Entities.Skill.Skill> _skills;

        public SkillSimulationLoader(IList<Entities.Skill.Skill> skills)
        {
            _skills = skills;
        }
        
        public void PopulateFromAssets(string assetsPath)
        {
            var document = LoadDocument($"{assetsPath}/Simulation/SimulationDescriptors_Skill.xml");
            _skills.ForEach(skill => 
                skill.Levels.ForEach(level => PopulateLevelDescriptors(skill, level, document)));
        }

        private void PopulateLevelDescriptors(Entities.Skill.Skill skill, SkillLevel level, XmlDocument document)
        {
            level.Descriptors = new Collection<SkillDescriptor>();
            PopulateSelfLevelDescriptor(skill, level, document);
            PopulateTargetLevelDescriptor(skill, level, document);
        }
        
        private void PopulateSelfLevelDescriptor(Entities.Skill.Skill skill, SkillLevel level, XmlDocument document)
            => PopulateDescriptor(skill, level, document, false);
        
        private void PopulateTargetLevelDescriptor(Entities.Skill.Skill skill, SkillLevel level, XmlDocument document) 
            => PopulateDescriptor(skill, level, document, true);

        private void PopulateDescriptor(Entities.Skill.Skill skill, SkillLevel level, XmlDocument document, bool applyToTarget)
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
                    Value =  (float)Convert.ToDouble(x.Attributes["Value"].Value),
                    Path = x.Attributes["Path"]?.Value
                })
                .ToList();
        }
    }
}