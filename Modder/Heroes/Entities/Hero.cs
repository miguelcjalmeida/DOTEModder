using Modder.Common;
using Modder.HeroItems.Entities;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modder.Heroes.Entities
{
    public class Hero : TitleDescriptionEntity
    {
        public string Name { get; set; }
        public int RecruitmentFoodCost { get; set; }
        public AITargetType AITargetType { get; set; }

        public AttackType AttackType { get; set; }

        public Localization Archetype { get; set; }
        public int UnlockLevelCount { get; set; }
        public Faction Faction { get; set; }

        public IList<Dialog> IntroDialogs { get; set; }
        public IList<EquipmentSlot> EquipmentSlots { get; set; }
        public IList<HeroLevel> Levels { get; set; }
        public string SmallIconPath { get; set; }
        public string LargeIconPath { get; set; }
        public Description Title { get; set; }
        public Description Description { get; set; }
        public string Identifier
        {
            get => $"Hero_{Name}";
            set => Name = value.Replace("Hero_", "");
        }
        public string LocalizationTitlePlaceholder => $"%Hero_{Name}_Title";
        public string LocalizationDescriptionPlaceholder => $"%Hero_{Name}_Biography";

        public void UnlearnSkill(string skillId)
        {
            Levels.ForEach(level =>
                level.Skills.Remove(skillId));
        }

        public void UnlearnSkill(Skill skill)
        {
            UnlearnSkill(skill.Identifier);
        }

        public void LearnSkillAt(string skillId, int level)
        {
            var levelFound = Levels.FirstOrDefault(x => x.Level == level);
            if (levelFound == null) return;
            levelFound.Skills.Remove(skillId);
            levelFound.Skills.Add(skillId);
            return;
        }
        public void LearnSkillAt(Skill skill, int level)
        {
            LearnSkillAt(skill.Identifier, level);
        }

        public void ReplaceSkill(string originId, string targetId)
        {
            Levels.ForEach(level =>
            {
                level.Skills.ForEach((skill, index) =>
                {
                    if (!skill.Contains(originId)) return;
                    level.Skills[index] = skill.Replace(originId, targetId);
                });
            });
        }

        public void ReplaceSkill(Skill origin, Skill target)
        {
            ReplaceSkill(origin.Identifier, target.Identifier);
        }
    }
}
