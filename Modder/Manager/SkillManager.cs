using System.Collections.Generic;
using Modder.Entities.Localization;
using Modder.Entities.Skill;
using Modder.Loaders.Skills;
using Modder.Writers;
using Modder.Writers.Skills;

namespace Modder.Manager
{
    public class SkillManager : DefaultEntityManager<Skill, SkillLoader, SkillWriter>
    {
        public SkillManager(string assetsPath, string distPath, IList<Localization> localizations, SkillLoader loader,
            SkillWriter writer, LocalizationWriter localizationWriter) : base(assetsPath, distPath, localizations,
            loader, writer, localizationWriter)
        {
        }
    }
}