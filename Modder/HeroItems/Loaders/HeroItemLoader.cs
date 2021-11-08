using System.Collections.Generic;
using Modder.Common.Loaders;
using Modder.HeroItems.Entities;
using Modder.Localizations.Entities;
using Modder.Localizations.Loaders;

namespace Modder.HeroItems.Loaders
{
    public class HeroItemLoader : Loader<HeroItem>
    {
        private readonly IList<Localization> _localizations;

        public HeroItemLoader(IList<Localization> localizations)
        {
            _localizations = localizations;
        }

        public IList<HeroItem> LoadFromAssets(string assetsPath)
        {
            var items = new HeroItemConfigurationLoader().LoadFromAssets(assetsPath);
            new HeroItemGuiLoader(items).PopulateFromAssets(assetsPath);
            new HeroItemSimulationLoader(items).PopulateFromAssets(assetsPath);
            new TitleDescriptionEntityPopulator<HeroItem>(_localizations).PopulateWith(items);
            return items;
        }
    }
}