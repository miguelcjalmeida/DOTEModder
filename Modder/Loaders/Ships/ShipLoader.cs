using System.Collections.Generic;
using Modder.Entities.Localization;
using Modder.Entities.Ship;
using Modder.Loaders.Localizations;

namespace Modder.Loaders.Ships
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