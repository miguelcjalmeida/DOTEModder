using Modder.Entities.Ship;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Modder.Writers.Ships
{
    public class ShipConfigsWriter : BaseDataTableWriter<IList<Ship>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Configuration/ShipConfigs.xml";

        protected override void WriteContent(XmlWriter writer, IList<Ship> skills)
            => skills.ForEach(x => WriteShipConfig(writer, x));

        private void WriteShipConfig(XmlWriter writer, Ship ship)
        {
            writer.WriteStartElement("ShipConfig");
            writer.WriteAttributeString("Name", ship.Name);
            writer.WriteAttributeString("LevelCount", ship.LevelCount.ToString());
            writer.WriteAttributeString("AbscissaValue", ship.AbscissaValue.ToString());

            writer.WriteOptionalAttribute("ForbiddenAITarget", ship.ForbiddenAITarget);
            writer.WriteOptionalAttribute("ForbidHeal", ship.ForbidHeal);
            writer.WriteOptionalAttribute("ForbidMultiplayer", ship.ForbidMultiplayer);
            writer.WriteOptionalAttribute("ForbidPause", ship.ForbidPause);
            writer.WriteOptionalAttribute("ForbidStrategyHealthRegen", ship.ForbidStrategyHealthRegen);
            writer.WriteOptionalAttribute("ForbidUnpower", ship.ForbidUnpower);
            writer.WriteOptionalAttribute("CrystalType", ship.CrystalType);
            writer.WriteOptionalAttribute("UseAlternativePulseFX", ship.UseAlternativePulseFX);
            writer.WriteOptionalAttribute("UseLightColorShift", ship.UseLightColorShift);
            writer.WriteOptionalAttribute("UseWallProps", ship.UseWallProps);

            writer.WriteStartElement("InitialBluePrints");
            ship.InitialBluePrints.ForEach(x => writer.WriteElementString("BluePrint", x));
            writer.WriteFullEndElement();

            writer.WriteStartElement("UnavailableBluePrints");
            ship.UnavailableBluePrints.ForEach(x => writer.WriteElementString("BluePrint", x));
            writer.WriteFullEndElement();

            writer.WriteStartElement("InitialItems");
            ship.InitialItems.ForEach(x => {
                writer.WriteStartElement("Item");
                writer.WriteAttributeString("Name", x);
                writer.WriteEndElement();
            });
            writer.WriteFullEndElement();

            writer.WriteStartElement("UnavailableItems");
            ship.UnavailableItems.ForEach(x => writer.WriteElementString("Item", x));
            writer.WriteFullEndElement();

            writer.WriteEndElement();
        }
    }
}
