using Modder.Heroes.Loaders;
using Modder.Heroes.Managers;
using Modder.Heroes.Writers;
using Modder.HeroItems.Loaders;
using Modder.HeroItems.Managers;
using Modder.HeroItems.Writers;
using Modder.Localizations.Entities;
using Modder.Localizations.Loaders;
using Modder.Localizations.Writers;
using Modder.Ships.Loaders;
using Modder.Ships.Managers;
using Modder.Ships.Writers;
using Modder.Skills.Loaders;
using Modder.Skills.Managers;
using Modder.Skills.Writers;

namespace Modder.Common.Managers
{
    public class EntitiesManagerFactory
    {
        public EntitiesManager Create(string assetsPath, string distPath)
        {
            var localizationsLoader = new LocalizationLoader();
            var localizations = localizationsLoader.LoadFromAssets(assetsPath);
            var localizationWriter = new LocalizationWriter();
            var heroItemLoader = new HeroItemLoader(localizations);
            var heroItemWriter = new HeroItemWriter();
            var heroItemManager = new HeroItemManager(assetsPath, distPath, localizations, heroItemLoader, heroItemWriter, localizationWriter);
            var skillLoader = new SkillLoader(localizations);
            var skillWriter = new SkillWriter();
            var skillManager = new SkillManager(assetsPath, distPath, localizations, skillLoader, skillWriter, localizationWriter);

            var shipLoader = new ShipLoader(localizations);
            var shipWriter = new ShipWriter();
            var shipManager = new ShipManager(assetsPath, distPath, localizations, shipLoader, shipWriter, localizationWriter);

            var localizationProvider = new LocalizationProvider(localizations);
            var heroWriter = new HeroWriter();
            var heroLoader = new HeroLoader(localizations, localizationProvider);
            var heroManager = new HeroManager(assetsPath, distPath, localizations, heroLoader, heroWriter, localizationWriter);

            return new EntitiesManager(heroItemManager, skillManager, shipManager, heroManager);
        }
    }
}