using System.Collections.Generic;
using Modder.Loaders.Localization;

namespace Modder.Loaders.Skill
{
    public class SkillLoader : Loader<Entities.Skill.Skill>
    {
        private readonly IList<Entities.Localization.Localization> _localizations;

        public SkillLoader(IList<Entities.Localization.Localization> localizations)
        {
            _localizations = localizations;
        }
        
        public IList<Entities.Skill.Skill> LoadFromAssets(string assetsPath)
        {
            var skills = new SkillConfigurationXmlLoader().LoadFromAssets(assetsPath);
            new SkillGuiXmlLoader(skills).PopulateFromAssets(assetsPath);
            new SkillSimulationXmlLoader(skills).PopulateFromAssets(assetsPath);
            new TitleDescriptionEntityPopulator<Entities.Skill.Skill>(_localizations).PopulateWith(skills);
            return skills;
        }
    }
}