﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Modder.Item;

namespace Modder.Writers
{
    public class HeroItemGuiWriter : DataTableWriter<IList<HeroItem>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Gui/GuiElements_ItemHero.xml";
        
        protected override void WriteContent(XmlWriter writer, IList<HeroItem> items)
            => items.ForEach(x => WriteGuiElement(writer, x));
        
        private static void WriteGuiElement(XmlWriter writer, HeroItem item)
        {
            writer.WriteStartElement("GuiElement");
            writer.WriteAttributeString("Name", item.Name);
            WriteTitle(writer, item);
            WriteDescription(writer, item);
            WriteIcon(writer, item);
            writer.WriteEndElement();
        }
        
        private static void WriteTitle(XmlWriter writer, HeroItem item)
        {
            writer.WriteStartElement("Title");
            writer.WriteValue(item.LocalizationTitlePlaceholder);
            writer.WriteEndElement();
        }
        
        private static void WriteDescription(XmlWriter writer, HeroItem item)
        {
            writer.WriteStartElement("Description");
            writer.WriteValue(item.LocalizationDescriptionPlaceholder);
            writer.WriteEndElement();
        }
        
        private static void WriteIcon(XmlWriter writer, HeroItem item)
        {
            writer.WriteStartElement("Icons");
            writer.WriteStartElement("Icon");
            writer.WriteAttributeString("Size", "Small");
            writer.WriteAttributeString("Path", item.IconPath);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}