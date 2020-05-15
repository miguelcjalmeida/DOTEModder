using System.Collections.Generic;
using System.Linq;
using Modder.Entities.Localization;

namespace Modder.Loaders.Localization
{
    public class TitleDescriptionEntityPopulator<TEntity> where TEntity : TitleDescriptionEntity
    {
        private readonly IList<Entities.Localization.Localization> _localizations;

        public TitleDescriptionEntityPopulator(IList<Entities.Localization.Localization> localizations)
        {
            _localizations = localizations;
        }
        
        public void PopulateWith(IList<TEntity> items)
        {
            items.ForEach(x =>
            {
                var skillTitle = _localizations.First(localization => localization.Name == x.LocalizationTitlePlaceholder);
                var skillDescription = _localizations.First(localization => localization.Name == x.LocalizationDescriptionPlaceholder);

                x.Title = skillTitle.Description;
                x.Description = skillDescription.Description;
            });
        }
    }
}