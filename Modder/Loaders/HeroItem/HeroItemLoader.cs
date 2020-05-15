using System.Collections.Generic;
using Modder.Loaders.Localization;

namespace Modder.Loaders.HeroItem
{
    public class HeroItemLoader : Loader<Entities.Item.HeroItem>
    {
        private readonly IList<Entities.Localization.Localization> _localizations;

        public HeroItemLoader(IList<Entities.Localization.Localization> localizations)
        {
            _localizations = localizations;
        }
        
        public IList<Entities.Item.HeroItem> LoadFromAssets(string assetsPath)
        {
            var items = new HeroItemConfigurationLoader().LoadFromAssets(assetsPath);
            new HeroItemGuiLoader(items).PopulateFromAssets(assetsPath);
            new HeroItemSimulationLoader(items).PopulateFromAssets(assetsPath);
            new TitleDescriptionEntityPopulator<Entities.Item.HeroItem>(_localizations).PopulateWith(items);
            return items;
        }
    }
}