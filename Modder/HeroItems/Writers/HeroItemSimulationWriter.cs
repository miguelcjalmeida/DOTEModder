using System;
using System.Collections.Generic;
using System.Xml;
using Modder.Common;
using Modder.Common.Writers;
using Modder.HeroItems.Entities;
using Modder.HeroItems.Entities.SimulationDescriptor;

namespace Modder.HeroItems.Writers
{
    public class HeroItemSimulationWriter : BaseDataTableWriter<IList<HeroItem>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Simulation/SimulationDescriptors_ItemHero.xml";

        protected override void WriteContent(XmlWriter writer, IList<HeroItem> skills)
            => skills.ForEach(x => WriteDescriptors(writer, x));

        private void WriteDescriptors(XmlWriter writer, HeroItem item)
        {
            item.Descriptors.ForEach(x => WriteDescriptor(writer, item, x));
        }

        private void WriteDescriptor(XmlWriter writer, HeroItem item, HeroItemDescriptor descriptor)
        {
            writer.WriteStartElement("SimulationDescriptor");
            writer.WriteAttributeString("Name", descriptor.GetName(item.Name));
            writer.WriteAttributeString("Type", descriptor.GetType(item.Name));
            WriteModifiers(writer, item, descriptor);
            writer.WriteEndElement();
        }

        private void WriteModifiers(XmlWriter writer, HeroItem item, HeroItemDescriptor descriptor)
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
            writer.WriteAttributeString("Value", FormatModifierValue(modifier.Value));
            writer.WriteEndElement();
        }

        private string FormatModifierValue(float value)
            => Formatter.FormatNumericValue(value);
    }
}