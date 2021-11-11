using System.Collections.Generic;
using Modder.Common.Loaders;
using Modder.Heroes.Entities;
using Modder.HeroItems.Entities;
using Modder.HeroItems.Loaders;
using Modder.Localizations.Entities;
using Modder.Localizations.Loaders;

namespace Modder.Heroes.Loaders
{
    public class HeroLoader : Loader<Hero>
    {
        private readonly IList<Localization> _localizations;
        private readonly LocalizationProvider _localizationProvider;

        public HeroLoader(IList<Localization> localizations, LocalizationProvider localizationProvider)
        {
            _localizations = localizations;
            _localizationProvider = localizationProvider;
        }

        public IList<Hero> LoadFromAssets(string assetsPath)
        {
            var items = new HeroConfigurationLoader(_localizationProvider).LoadFromAssets(assetsPath);
            new HeroLevelConfigsLoader(items).PopulateFromAssets(assetsPath);
            new TitleDescriptionEntityPopulator<Hero>(_localizations).PopulateWith(items);
            return items;
        }
    }
}