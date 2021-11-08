using System.Collections.Generic;
using Modder.Common.Managers;
using Modder.HeroItems.Entities;
using Modder.HeroItems.Loaders;
using Modder.HeroItems.Writers;
using Modder.Localizations.Entities;
using Modder.Localizations.Writers;

namespace Modder.HeroItems.Managers
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