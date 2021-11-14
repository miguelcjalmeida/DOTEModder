using System.Collections.Generic;
using System.Linq;
using Modder.Localizations.Entities;

namespace Modder.Skills.Entities
{
    public class Skill : TitleDescriptionEntity
    {
        public string Name { get; set; }
        public Description Title { get; set; }
        public Description Description { get; set; }
        public string Icon { get; set; }
        public IList<SkillLevel> Levels { get; set; }
        public bool HiddenFromConfigurationFile { get; set; }

        public string Identifier
        {
            get => $"Skill_{SkillTypeIdentifier}{Name}";
            set => Name = value.Replace("Skill_A", "").Replace("Skill_P", "");
        }

        public string SkillTypeIdentifier
        {
            get => Levels.Any(x => x.IsActive) ? "A" : "P";
        }

        public string LocalizationTitlePlaceholder => $"%{Identifier}_Title";
        public string LocalizationDescriptionPlaceholder => $"%{Identifier}_Description";
    }
}