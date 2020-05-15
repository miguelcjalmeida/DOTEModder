using System.Collections.Generic;

namespace Modder.Loaders.Skill
{
    public class SkillLoader
    {
        public IList<Entities.Skill.Skill> LoadFromAssets(string assetsPath)
        {
            var skills = new SkillConfigurationLoader().LoadFromAssets(assetsPath);
            new SkillGuiLoader(skills).PopulateFromAssets(assetsPath);
            new SkillSimulationLoader(skills).PopulateFromAssets(assetsPath);
            return skills;
        }
    }
}