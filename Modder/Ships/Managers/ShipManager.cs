using Modder.Common.Managers;
using Modder.Localizations.Entities;
using Modder.Localizations.Writers;
using Modder.Ships.Entities;
using Modder.Ships.Loaders;
using Modder.Ships.Writers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Ships.Managers
{
    public class ShipManager : DefaultEntityManager<Ship, ShipLoader, ShipWriter>
    {
        public ShipManager(string assetsPath, string distPath, IList<Localization> localizations, ShipLoader loader, ShipWriter writer, LocalizationWriter localizationWriter) : base(assetsPath, distPath, localizations, loader, writer, localizationWriter)
        {
        }
    }
}
