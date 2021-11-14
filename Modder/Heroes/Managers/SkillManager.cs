using System.Collections.Generic;
using Modder.Common.Managers;
using Modder.Heroes.Entities;
using Modder.Heroes.Loaders;
using Modder.Heroes.Writers;
using Modder.Localizations.Entities;
using Modder.Localizations.Writers;

namespace Modder.Heroes.Managers
{
    public class HeroManager : DefaultEntityManager<Hero, HeroLoader, HeroWriter>
    {
        public HeroManager(string assetsPath, string distPath, IList<Localization> localizations, HeroLoader loader,
            HeroWriter writer, LocalizationWriter localizationWriter) : base(assetsPath, distPath, localizations,
            loader, writer, localizationWriter)
        {
        }
    }
}