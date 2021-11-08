using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Common;
using Modder.Common.Writers;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Skills.Entities;

namespace Modder.Skills.Writers
{
    public class SkillSimulationWriter : BaseDataTableWriter<IList<Skill>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Simulation/SimulationDescriptors_Skill.xml";

        protected override void WriteContent(XmlWriter writer, IList<Skill> skills)
        {
            WriteSkillClass(writer);
            skills.ForEach(x => WriteDescriptors(writer, x));
        }

        private void WriteSkillClass(XmlWriter writer)
        {
            writer.WriteStartElement("SimulationDescriptor");
            writer.WriteAttributeString("Name", "Skill");
            writer.WriteAttributeString("Type", "Class");
            writer.WriteStartElement("SimulationPropertyDescriptors");
            writer.WriteComment("empty");
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void WriteDescriptors(XmlWriter writer, Skill skill)
        {
            skill.Levels.ForEach(level =>
                level.Descriptors
                    .Where(x => !x.AppliesToTarget)
                    .ForEach(x => WriteDescriptor(writer, skill, level, x)));

            skill.Levels.ForEach(level =>
                level.Descriptors
                    .Where(x => x.AppliesToTarget)
                    .ForEach(x => WriteDescriptor(writer, skill, level, x)));
        }

        private void WriteDescriptor(XmlWriter writer, Skill skill, SkillLevel level, SkillDescriptor descriptor)
        {
            writer.WriteStartElement("SimulationDescriptor");
            writer.WriteAttributeString("Name", descriptor.GetIdentifier(skill, level));
            writer.WriteAttributeString("Type", descriptor.GetType(level));
            WriteModifiers(writer, descriptor);
            writer.WriteEndElement();
        }

        private void WriteModifiers(XmlWriter writer, SkillDescriptor descriptor)
        {
            writer.WriteStartElement("SimulationModifierDescriptors");
            descriptor.Modifiers.ForEach(x => WriteModifier(writer, x));
            writer.WriteEndElement();
        }

        private void WriteModifier(XmlWriter writer, ModifierDescriptor modifier)
        {
            writer.WriteStartElement("SimulationModifierDescriptor");
            writer.WriteAttributeString("TargetProperty", modifier.TargetProperty.ToString());
            writer.WriteAttributeString("Operation", modifier.Operation.ToString());
            writer.WriteAttributeString("Value", Formatter.FormatNumericValue(modifier.Value));
            if (modifier.Path != null) writer.WriteAttributeString("Path", modifier.Path);
            writer.WriteEndElement();
        }
    }
}