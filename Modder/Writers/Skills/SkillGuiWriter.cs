﻿using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Entities.Item;
using Modder.Entities.Skill;

namespace Modder.Writers.Skills
{
    public class SkillGuiWriter : DataTableWriter<IList<Skill>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Gui/GuiElements_Skill.xml";

        protected override void WriteContent(XmlWriter writer, IList<Skill> skills)
        {
            skills.ForEach(x => WriteGuiElement(writer, x));
            GetHardcodedSkills().ForEach(x => WriteGuiElement(writer, x));
        }

        private void WriteGuiElement(XmlWriter writer, Skill skill)
        {
            writer.WriteStartElement("GuiElement");
            writer.WriteAttributeString("Name", skill.Identifier);
            WriteTitle(writer, skill);
            WriteDescription(writer, skill);
            WriteIcons(writer, skill);
            writer.WriteEndElement();
        }
        
        private void WriteTitle(XmlWriter writer, Skill skill)
        {
            writer.WriteStartElement("Title");
            writer.WriteValue(skill.LocalizationTitlePlaceholder);
            writer.WriteEndElement();
        }
        
        private void WriteDescription(XmlWriter writer, Skill skill)
        {
            writer.WriteStartElement("Description");
            writer.WriteValue(skill.LocalizationDescriptionPlaceholder);
            writer.WriteEndElement();
        }
        
        private void WriteIcons(XmlWriter writer, Skill skill)
        {
            writer.WriteStartElement("Icons");
            WriteIcon(writer, "Small", skill.Icon);
            
            if (skill.Levels.Any(x => x.IsActive)) 
                WriteIcon(writer, "Large", $"{skill.Icon}_over");

            writer.WriteEndElement();
        }
        
        private void WriteIcon(XmlWriter writer, string size, string path)
        {
            writer.WriteStartElement("Icon");
            writer.WriteAttributeString("Size", size);
            writer.WriteAttributeString("Path", path);
            writer.WriteEndElement();
        }

        private IList<Skill> GetHardcodedSkills()
        {
            var identifiers = new List<string> { "Skill_A0010" };
            return identifiers
                .Select(identifier => new Skill
                {
                    Identifier = identifier,
                    Icon = $"GUI/DynamicBitmaps/Skills/{identifier}",
                    Levels = new List<SkillLevel> { new SkillLevel { IsActive = true } }
                })
                .ToList();
        }
    }
}