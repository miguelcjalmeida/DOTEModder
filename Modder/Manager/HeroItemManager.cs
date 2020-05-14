using System.Collections.Generic;
using System.Linq;
using Modder.Item;
using Modder.Loaders.HeroItem;
using Modder.Loaders.Localization;
using Modder.Writers;

namespace Modder.Manager
{
    public interface IHeroItemManager
    {
        IList<HeroItem> Load();
        void Save(IList<HeroItem> items);
    }
    
    public class HeroItemItemManager : IHeroItemManager
    {
        private readonly string _assetsPath;
        private readonly string _distPath;
        private readonly HeroItemLoader _itemLoader = new HeroItemLoader();
        private readonly LocalizationLoader _localizationLoader = new LocalizationLoader();
        private readonly HeroItemWriter _heroItemWriter = new HeroItemWriter();
        private readonly LocalizationWriter _localizationWriter = new LocalizationWriter();

        public HeroItemItemManager(string assetsPath, string distPath)
        {
            _assetsPath = assetsPath;
            _distPath = distPath;
        }
        
        public IList<HeroItem> Load() => _itemLoader.LoadFromAssets(_assetsPath);

        public void Save(IList<HeroItem> items)
        {
            var localizations = _localizationLoader.LoadFromAssets(_assetsPath);

            items.ForEach(item =>
            {
                SetLocalizationText(localizations, item.LocalizationTitlePlaceholder, item.Title);
                SetLocalizationText(localizations, item.LocalizationDescriptionPlaceholder, item.Description);
            });
            
            _heroItemWriter.Write(_distPath, items);
            _localizationWriter.Write(_distPath, localizations);
        }

        private void SetLocalizationText(IList<Localization> localizations, string placeholder, Description newDescription)
        {
            var localization = localizations.FirstOrDefault(x => x.Name == placeholder);

            if (localization == null)
            {
                localizations.Add(new Localization(placeholder, newDescription));
                return;
            }
            
            localization.Description = newDescription;
        }
    }
}