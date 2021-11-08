using Modder.Localizations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Ships.Entities
{
    public class Ship : TitleDescriptionEntity
    {
        public string Name { get; set; }
        public int LevelCount { get; set; }
        public int AbscissaValue { get; set; }
        public CrystalType? CrystalType { get; set; }
        public bool? ForbidStrategyHealthRegen { get; set; }
        public bool? ForbidHeal { get; set; }
        public bool? ForbidMultiplayer { get; set; }
        public bool? ForbidPause { get; set; }
        public bool? ForbidUnpower { get; set; }
        public string ForbiddenAITarget { get; set; }
        public bool? UseWallProps { get; set; }
        public bool? UseAlternativePulseFX { get; set; }
        public bool? UseLightColorShift { get; set; }
        public IList<string> InitialBluePrints { get; set; }
        public IList<string> UnavailableBluePrints { get; set; }
        public IList<string> InitialItems { get; set; }
        public IList<string> UnavailableItems { get; set; }
        public Description Title { get; set; }
        public Description Description { get; set; }

        public string LocalizationTitlePlaceholder => $"%ShipTitle_{Name}";

        public string LocalizationDescriptionPlaceholder => $"%ShipDescription_{Name}";
    }
}
