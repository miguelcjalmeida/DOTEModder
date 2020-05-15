using System.Collections.Generic;
using System.Xml;
using Modder.Entities.Skill;

namespace Modder.Writers.Skills
{
    public class SkillConfigsWriter : BaseDataTableWriter<IList<Skill>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Configuration/SkillConfigs.xml";

        protected override void WriteContent(XmlWriter writer, IList<Skill> skills)
            => skills.ForEach(x => WriteSkillConfig(writer, x));
        
        private void WriteSkillConfig(XmlWriter writer, Skill skill)
        {
            skill.Levels.ForEach(level =>
            {
                writer.WriteStartElement("SkillConfig");
                writer.WriteAttributeString("Name", level.GetIdentifier(skill));
                WriteNumericBoolAttribute(writer, "IsActive", level.IsActive);
                if (level.IsActive)
                {
                    WriteNumericAttribute(writer, "Duration", level.Duration);
                    WriteNumericAttribute(writer, "CooldownTurnsCount", level.CooldownTurnsCount);
                }               
                WriteBoolAttribute(writer, "DeactivateOnNewTurn", level.DeactivateOnNewTurn);
                WriteStringAttribute(writer, "DamagesTargetsPath", level.DamagesTargetsPath);
                WriteStringAttribute(writer, "OwnerVFXPath", level.OwnerVFXPath);
                WriteStringAttribute(writer, "TargetVFXPath", level.TargetVFXPath);
                WriteStringAttribute(writer, "OwnerSFXPath", level.OwnerSFXPath);
                WriteStringAttribute(writer, "DialogVFXPath", level.DialogVFXPath);
                WriteStringAttribute(writer, "TargetSFXPath", level.TargetSFXPath);
                writer.WriteEndElement();
            });
        }
        
        private void WriteNumericBoolAttribute(XmlWriter writer, string key, bool value)
        {
            if (value) writer.WriteAttributeString(key, "1");
        }
        
        private void WriteBoolAttribute(XmlWriter writer, string key, bool value)
        {
            if (value) writer.WriteAttributeString(key, "true");
        }
        
        private void WriteNumericAttribute(XmlWriter writer, string key, float value)
        {
            writer.WriteAttributeString(key, Formatter.FormatNumericValue(value));
        }
        
        private void WriteStringAttribute(XmlWriter writer, string key, string text)
        {
            if (text != null) writer.WriteAttributeString(key, text);
        }
    }
}