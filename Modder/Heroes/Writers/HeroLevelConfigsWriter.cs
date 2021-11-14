using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Common;
using Modder.Common.Writers;
using Modder.Heroes.Entities;

namespace Modder.Heroes.Writers
{
    public class HeroLevelConfigsWriter : BaseDataTableWriter<IList<Hero>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Configuration/HeroLevelConfigs.xml";

        protected override void WriteContent(XmlWriter writer, IList<Hero> hero)
            => hero.ForEach(x => WriteHeroLevels(writer, x));

        private void WriteHeroLevels(XmlWriter writer, Hero hero)
        {
            hero.Levels.ForEach(level =>
            {
                writer.WriteStartElement("HeroLevelConfig");
                writer.WriteAttributeString("Name", level.GetFullIdentifier(hero.Name));
                writer.WriteAttributeString("FoodCost", XmlTranslation.AsText(level.FoodCost));
                WriteSkills(writer, level);
                writer.WriteEndElement();
            });
        }

        private void WriteSkills(XmlWriter writer, HeroLevel level)
        {
            if (level.Skills.Count == 0) return;

            writer.WriteStartElement("Skills");
            level.Skills.ForEach(skill =>
            {
                writer.WriteStartElement("Skill");
                writer.WriteString(skill);
                writer.WriteEndElement();
            });
            writer.WriteEndElement();
        }
    }
}