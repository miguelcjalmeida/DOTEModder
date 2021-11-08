using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Common.Loaders;
using Modder.Ships.Entities;

namespace Modder.Ships.Loaders
{
    public class ShipConfigurationLoader : XmlLoader
    {
        public IList<Ship> LoadFromAssets(string assetsPath)
        {
            var heroItemsDoc = LoadDocument($"{assetsPath}/Configuration/ShipConfigs.xml");
            var itemsNodes = heroItemsDoc.SelectNodes("Datatable/ShipConfig");
            return itemsNodes.AsQuery()
                .Select(CreateShipFromNode)
                .ToList();
        }

        private static Ship CreateShipFromNode(XmlNode shipConfig)
        {
            var depthRange = shipConfig.SelectSingleNode("DepthRanges/DepthRange");
            var category = shipConfig.SelectSingleNode("Category");
            var skills = shipConfig.SelectNodes("Skills/Skill");

            return new Ship
            {
                Name = shipConfig.Attributes["Name"].Value,
                AbscissaValue = Convert.ToInt32(shipConfig.Attributes["AbscissaValue"].Value),
                LevelCount = Convert.ToInt32(shipConfig.Attributes["LevelCount"].Value),
                CrystalType = shipConfig.Attributes["CrystalType"]?.Value.ParseToEnum<CrystalType>(),
                ForbiddenAITarget = shipConfig.Attributes["ForbiddenAITarget"]?.Value,
                ForbidHeal = ConvertToBool(shipConfig.Attributes["ForbidHeal"]?.Value),
                ForbidMultiplayer = ConvertToBool(shipConfig.Attributes["ForbidMultiplayer"]?.Value),
                ForbidPause = ConvertToBool(shipConfig.Attributes["ForbidPause"]?.Value),
                ForbidStrategyHealthRegen = ConvertToBool(shipConfig.Attributes["ForbidStrategyHealthRegen"]?.Value),
                ForbidUnpower = ConvertToBool(shipConfig.Attributes["ForbidUnpower"]?.Value),
                UseAlternativePulseFX = ConvertToBool(shipConfig.Attributes["UseAlternativePulseFX"]?.Value),
                UseLightColorShift = ConvertToBool(shipConfig.Attributes["UseLightColorShift"]?.Value),
                UseWallProps = ConvertToBool(shipConfig.Attributes["UseAlternativePulseFX"]?.Value),
                InitialBluePrints = shipConfig.SelectNodes("InitialBluePrints/BluePrint").AsQuery().Select(x => x.InnerText).ToList(),
                InitialItems = shipConfig.SelectNodes("InitialItems/Item").AsQuery().Select(x => x.Attributes["Name"]?.Value ?? "").ToList(),
                UnavailableBluePrints = shipConfig.SelectNodes("UnavailableBluePrints/BluePrint").AsQuery().Select(x => x.InnerText).ToList(),
                UnavailableItems = shipConfig.SelectNodes("UnavailableItems/Item").AsQuery().Select(x => x.InnerText).ToList(),
            };
        }

        private static bool? ConvertToBool(string value)
        {
            if (value == null) return null;
            return Convert.ToBoolean(value);
        }
    }
}