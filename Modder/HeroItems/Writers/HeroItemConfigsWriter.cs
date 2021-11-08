using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Common;
using Modder.Common.Writers;
using Modder.HeroItems.Entities;
using Modder.HeroItems.Entities.SimulationDescriptor;

namespace Modder.HeroItems.Writers
{
    public class HeroItemConfigsWriter : BaseDataTableWriter<IList<HeroItem>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Configuration/ItemHeroConfigs.xml";

        protected override void WriteContent(XmlWriter writer, IList<HeroItem> skills)
            => skills.ForEach(x => WriteItemHeroConfig(writer, x));

        private void WriteItemHeroConfig(XmlWriter writer, HeroItem item)
        {
            writer.WriteStartElement("ItemHeroConfig");
            writer.WriteAttributeString("Name", item.Name);
            writer.WriteAttributeString("MaxCount", "-1");

            if (item.AttackType != null)
                writer.WriteAttributeString("AttackType", item.AttackType.ToString());

            writer.WriteAttributeString("ItemType", "ItemHero");
            WriteDepthRanges(writer, item.DropCriteria);
            WriteCategory(writer, item);
            WriteSkills(writer, item);
            WriteRarities(writer, item);
            writer.WriteEndElement();
        }

        private void WriteDepthRanges(XmlWriter writer, DropCriteria itemDropCriteria)
        {
            writer.WriteStartElement("DepthRanges");

            writer.WriteStartElement("DepthRange");
            writer.WriteAttributeString("LevelMin", itemDropCriteria.MinLevel.ToString());
            writer.WriteAttributeString("LevelMax", itemDropCriteria.MaxLevel.ToString());
            writer.WriteAttributeString("Start", "0");

            writer.WriteStartElement("ProbabilityWeight");
            writer.WriteAttributeString("StartValue", itemDropCriteria.ProbabilityWeight.ToString());
            writer.WriteAttributeString("DepthBonus", "0");
            writer.WriteAttributeString("MaxValue", "-1");
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void WriteCategory(XmlWriter writer, HeroItem item)
        {
            writer.WriteStartElement("Category");
            writer.WriteAttributeString("Name", item.Category.ToString());
            if (item.WeaponType != null) writer.WriteAttributeString("Type", item.WeaponType.ToString());
            writer.WriteEndElement();
        }

        private void WriteRarities(XmlWriter writer, HeroItem item)
        {
            writer.WriteStartElement("Rarities");
            item.Descriptors.ForEach(x => WriteRarity(writer, x));
            writer.WriteEndElement();
        }

        private void WriteRarity(XmlWriter writer, HeroItemDescriptor descriptor)
        {
            writer.WriteStartElement("Rarity");
            writer.WriteAttributeString("Name", descriptor.Rarity.Name.ToString());
            WriteDepthRanges(writer, descriptor.Rarity.DropCriteria);
            writer.WriteEndElement();
        }

        private void WriteSkills(XmlWriter writer, HeroItem item)
        {
            if (!item.SkillIDs.Any()) return;

            writer.WriteStartElement("Skills");
            item.SkillIDs.ForEach(skill =>
            {
                writer.WriteStartElement("Skill");
                writer.WriteString(skill);
                writer.WriteEndElement();
            });
            writer.WriteEndElement();
        }
    }
}