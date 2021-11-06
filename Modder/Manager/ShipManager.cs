using Modder.Entities.Localization;
using Modder.Entities.Ship;
using Modder.Loaders.Ships;
using Modder.Writers.Localizations;
using Modder.Writers.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Manager
{
    public class ShipManager : DefaultEntityManager<Ship, ShipLoader, ShipWriter>
    {
        public ShipManager(string assetsPath, string distPath, IList<Localization> localizations, ShipLoader loader, ShipWriter writer, LocalizationWriter localizationWriter) : base(assetsPath, distPath, localizations, loader, writer, localizationWriter)
        {
        }
    }
}
