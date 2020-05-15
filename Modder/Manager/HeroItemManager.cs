using System.Collections.Generic;
using Modder.Entities.HeroItem;
using Modder.Entities.Localization;
using Modder.Loaders.HeroItems;
using Modder.Writers;
using Modder.Writers.HeroItems;
using Modder.Writers.Localizations;

namespace Modder.Manager
{
    public class HeroItemManager : DefaultEntityManager<HeroItem, HeroItemLoader, HeroItemWriter>
    {
        public HeroItemManager(
            string assetsPath, string distPath, IList<Localization> localizations,
            HeroItemLoader loader, HeroItemWriter writer, LocalizationWriter localizationWriter) : base(assetsPath,
            distPath, localizations, loader, writer, localizationWriter)
        {
        }
    }
}