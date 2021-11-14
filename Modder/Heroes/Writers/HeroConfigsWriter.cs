using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Common;
using Modder.Common.Writers;
using Modder.Heroes.Entities;

namespace Modder.Heroes.Writers
{
    public class HeroConfigsWriter : BaseDataTableWriter<IList<Hero>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Configuration/HeroConfigs.xml";

        protected override void WriteContent(XmlWriter writer, IList<Hero> heroes)
            => heroes.ForEach(x => WriteHeroConfig(writer, x));

        private void WriteHeroConfig(XmlWriter writer, Hero hero)
        {
            writer.WriteStartElement("HeroConfig");
            writer.WriteAttributeString("Name", hero.Identifier);
            writer.WriteAttributeString("RecruitmentFoodCost", XmlTranslation.AsText(hero.RecruitmentFoodCost));
            writer.WriteAttributeString("AITargetType", XmlTranslation.AsText(hero.AITargetType));
            writer.WriteAttributeString("AttackType", XmlTranslation.AsText(hero.AttackType));
            writer.WriteAttributeString("Archetype", XmlTranslation.AsText(hero.Archetype));
            writer.WriteAttributeString("UnlockLevelCount", XmlTranslation.AsText(hero.UnlockLevelCount));
            writer.WriteAttributeString("Faction", XmlTranslation.AsText(hero.Faction));
            WriteIntroDialogs(writer, hero);
            WriteEquipmentSlots(writer, hero);
            writer.WriteEndElement();
        }

        private void WriteIntroDialogs(XmlWriter writer, Hero hero)
        {
            writer.WriteStartElement("IntroDialogs");
            hero.IntroDialogs.ForEach(dialog =>
            {
                writer.WriteStartElement("Dialog");
                writer.WriteAttributeString("Name", XmlTranslation.AsText(dialog.Name));
                writer.WriteAttributeString("Text", XmlTranslation.AsText(dialog.Text));
                writer.WriteEndElement();
            });
            writer.WriteEndElement();
        }

        private void WriteEquipmentSlots(XmlWriter writer, Hero hero)
        {
            writer.WriteStartElement("EquipmentSlots");
            hero.EquipmentSlots.ForEach(slot =>
            {
                writer.WriteStartElement("EquipmentSlot");
                writer.WriteAttributeString("Name", XmlTranslation.AsText(slot.Name));
                if (slot.Type != null) writer.WriteAttributeString("Type", XmlTranslation.AsText(slot.Type));
                writer.WriteEndElement();
            });
            writer.WriteEndElement();
        }
    }
}