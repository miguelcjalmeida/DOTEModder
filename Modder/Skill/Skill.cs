using System.Collections.Generic;

namespace Modder.Skill
{
    public class Skill
    {
        public string Name { get; set; }
        public Description Title { get; set; }
        public Description Description { get; set; }
        public string Icon { get; set; }
        public IList<SkillLevel> Levels { get; set; }

        public string Identifier
        {
            get => $"Skill_{Name}";
            set => Name = value.Replace("Skill_", "");
        }
        
        public string LocalizationTitlePlaceholder => $"%{Identifier}_Title";
        public string LocalizationDescriptionPlaceholder => $"%{Identifier}_Description";
    }
}