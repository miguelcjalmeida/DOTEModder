using System.Collections.Generic;
using Modder.Common.Managers;
using Modder.Localizations.Entities;
using Modder.Localizations.Writers;
using Modder.Skills.Entities;
using Modder.Skills.Loaders;
using Modder.Skills.Writers;

namespace Modder.Skills.Managers
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