using System.Collections.Generic;
using System.Xml;
using Modder.Common;
using Modder.Common.Writers;
using Modder.Heroes.Entities;

namespace Modder.Heroes.Writers
{
    public class HeroGuiWriter : BaseDataTableWriter<IList<Hero>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Gui/GuiElements_Hero.xml";

        protected override void WriteContent(XmlWriter writer, IList<Hero> heroes)
            => heroes.ForEach(x => WriteGuiElement(writer, x));

        private static void WriteGuiElement(XmlWriter writer, Hero hero)
        {
            writer.WriteStartElement("GuiElement");
            writer.WriteAttributeString("Name", hero.Identifier);
            WriteTitle(writer, hero);
            WriteDescription(writer, hero);
            WriteIcons(writer, hero);
            writer.WriteEndElement();
        }

        private static void WriteTitle(XmlWriter writer, Hero item)
        {
            writer.WriteStartElement("Title");
            writer.WriteValue(item.LocalizationTitlePlaceholder);
            writer.WriteEndElement();
        }

        private static void WriteDescription(XmlWriter writer, Hero item)
        {
            writer.WriteStartElement("Description");
            writer.WriteValue(item.LocalizationDescriptionPlaceholder);
            writer.WriteEndElement();
        }

        private static void WriteIcons(XmlWriter writer, Hero item)
        {
            writer.WriteStartElement("Icons");

            writer.WriteStartElement("Icon");
            writer.WriteAttributeString("Size", "Small");
            writer.WriteAttributeString("Path", item.SmallIconPath);
            writer.WriteEndElement();

            writer.WriteStartElement("Icon");
            writer.WriteAttributeString("Size", "Large");
            writer.WriteAttributeString("Path", item.LargeIconPath);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}