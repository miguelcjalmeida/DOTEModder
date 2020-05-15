using System.Collections.Generic;
using System.Linq;

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
            PopulateLocalizations(skills);
            return skills;
        }

        private void PopulateLocalizations(IList<Entities.Skill.Skill> skills)
        {
            skills.ForEach(x =>
            {
                var skillTitle = _localizations.First(localization => localization.Name == x.LocalizationTitlePlaceholder);
                var skillDescription = _localizations.First(localization => localization.Name == x.LocalizationDescriptionPlaceholder);

                x.Title = skillTitle.Description;
                x.Description = skillDescription.Description;
            });
        }
    }
}