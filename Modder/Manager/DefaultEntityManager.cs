using System.Collections.Generic;
using System.Linq;
using Modder.Entities.Localization;
using Modder.Loaders;
using Modder.Writers;
using Modder.Writers.Localizations;

namespace Modder.Manager
{
    public class DefaultEntityManager<TEntity, TLoader, TWriter> : IManager<TEntity> 
        where TEntity : TitleDescriptionEntity
        where TLoader : Loader<TEntity>
        where TWriter : DataTableWriter<IList<TEntity>> 
    {
        private readonly string _assetsPath;
        private readonly string _distPath;
        private readonly IList<Localization> _localizations;
        private readonly TLoader _loader;
        private readonly TWriter _writer;
        private readonly LocalizationWriter _localizationWriter;

        protected DefaultEntityManager(string assetsPath, string distPath, IList<Localization> localizations, TLoader loader, TWriter writer, LocalizationWriter localizationWriter)
        {
            _assetsPath = assetsPath;
            _distPath = distPath;
            _localizations = localizations;
            _loader = loader;
            _writer = writer;
            _localizationWriter = localizationWriter;
        }

        public IList<TEntity> Load() => _loader.LoadFromAssets(_assetsPath);

        public void Save(IList<TEntity> items)
        {
            items.ForEach(item =>
            {
                SetLocalizationText(item.LocalizationTitlePlaceholder, item.Title);
                SetLocalizationText(item.LocalizationDescriptionPlaceholder, item.Description);
            });
            
            _writer.Write(_distPath, items);
            _localizationWriter.Write(_distPath, _localizations);
        }

        private void SetLocalizationText(string placeholder, Description newDescription)
        {
            if (newDescription == null) return; 
            
            var localization = _localizations.FirstOrDefault(x => x.Name == placeholder);

            if (localization == null)
            {
                _localizations.Add(new Localization(placeholder, newDescription));
                return;
            }
            
            localization.Description = newDescription;
        }
    }
}