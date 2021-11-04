using System.Collections.Generic;
using System.Linq;
using Modder.Entities.Localization;
using Modder.Entities.Skill;
using Modder.Loaders.Localizations;

namespace Modder.Loaders.Skills
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