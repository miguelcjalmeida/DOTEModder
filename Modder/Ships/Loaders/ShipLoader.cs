using System.Collections.Generic;
using Modder.Common.Loaders;
using Modder.Localizations.Entities;
using Modder.Localizations.Loaders;
using Modder.Ships.Entities;

namespace Modder.Ships.Loaders
{
    public class ShipLoader : Loader<Ship>
    {
        private readonly IList<Localization> _localizations;

        public ShipLoader(IList<Localization> localizations)
        {
            _localizations = localizations;
        }

        public IList<Ship> LoadFromAssets(string assetsPath)
        {
            var items = new ShipConfigurationLoader().LoadFromAssets(assetsPath);
            new TitleDescriptionEntityPopulator<Ship>(_localizations).PopulateWith(items);
            return items;
        }
    }
}