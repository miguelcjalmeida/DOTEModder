using System.Collections.Generic;
using Modder.Common.Loaders;
using Modder.Localizations.Entities;
using Modder.Localizations.Loaders;
using Modder.Skills.Entities;

namespace Modder.Skills.Loaders
{
    public class SkillLoader : Loader<Skill>
    {
        private readonly IList<Localization> _localizations;

        public SkillLoader(IList<Localization> localizations)
        {
            _localizations = localizations;
        }

        public IList<Skill> LoadFromAssets(string assetsPath)
        {
            var skills = new SkillConfigurationXmlLoader().LoadFromAssets(assetsPath);
            new SkillHardcodedLoader(skills).Populate();
            new SkillGuiXmlLoader(skills).PopulateFromAssets(assetsPath);
            new SkillSimulationXmlLoader(skills).PopulateFromAssets(assetsPath);
            new TitleDescriptionEntityPopulator<Skill>(_localizations).PopulateWith(skills);
            return skills;
        }
    }
}