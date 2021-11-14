using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Common;
using Modder.Common.Writers;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Heroes.Entities;

namespace Modder.Heroes.Writers
{
    public class HeroSimulationWriter : BaseDataTableWriter<IList<Hero>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Simulation/SimulationDescriptors_Hero.xml";

        protected override void WriteContent(XmlWriter writer, IList<Hero> heroes)
        {
            heroes.ForEach(x => WriteDescriptors(writer, x));
        }

        private void WriteDescriptors(XmlWriter writer, Hero hero)
        {
            hero.Levels.ForEach(level =>
                level.Descriptors
                    .ForEach(x => WriteDescriptor(writer, hero, level, x)));
        }

        private void WriteDescriptor(XmlWriter writer, Hero hero, HeroLevel level, HeroDescriptor descriptor)
        {
            writer.WriteStartElement("SimulationDescriptor");
            writer.WriteAttributeString("Name", descriptor.GetIdentifier(hero.Name, level.Level));
            writer.WriteAttributeString("Type", XmlTranslation.AsText(descriptor.GetType(level.Level)));
            WriteModifiers(writer, descriptor);
            writer.WriteEndElement();
        }

        private void WriteModifiers(XmlWriter writer, HeroDescriptor descriptor)
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