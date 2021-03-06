﻿using Modder.Loaders.HeroItems;
using Modder.Loaders.Localizations;
using Modder.Loaders.Skills;
using Modder.Writers.HeroItems;
using Modder.Writers.Localizations;
using Modder.Writers.Skills;

namespace Modder.Manager
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
            return new EntitiesManager(heroItemManager, skillManager);
        }
    }
}