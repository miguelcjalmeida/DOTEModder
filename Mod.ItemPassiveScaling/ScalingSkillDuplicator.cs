using System.Collections.Generic;
using System.Linq;
using Modder;
using Modder.Entities.HeroItem.Rarity;
using Modder.Entities.HeroItem.SimulationDescriptor;
using Modder.Entities.Localization;
using Modder.Entities.Skill;

namespace Mod.ItemPassiveScaling
{
    public class ScalingSkillDuplicator
    {
        private readonly RarityName[] _rarity = {RarityName.Common, RarityName.Rarity0, RarityName.Rarity1, RarityName.Rarity2};
        private readonly SkillModifierEnhancer _enhancer = new SkillModifierEnhancer();
        
        public IList<Skill> Duplicate(IList<Skill> skills)
        {
            return skills.SelectMany(CreateSkillVersions).ToList();
        }

        private IList<Skill> CreateSkillVersions(Skill skill)
        {
            return _rarity
                .Select((rarity, index) => new Skill
                {
                    Name = $"{skill.Name}{RaritySuffix.FormatIdentifier(rarity)}",
                    Title = GetImprovedSkillTitle(skill.Title.Copy(), rarity),
                    Description = skill.Description,
                    Icon = skill.Icon,
                    HiddenFromConfigurationFile = skill.HiddenFromConfigurationFile,
                    Levels = CreateSkillLevelVersions(index, skill)
                })
                .ToList();
        }

        private IList<SkillLevel> CreateSkillLevelVersions(int rarity, Skill skill)
        {
            var levels = skill.Levels.Select(x => x.Copy()).ToList();
            
            levels.SelectMany(level => level.Descriptors)
                .SelectMany(descriptors => descriptors.Modifiers)
                .ForEach(modifier => _enhancer.Enhance(rarity, modifier));

            return levels;
        }
        
        private Description GetImprovedSkillTitle(Description title, RarityName rarity)
        {
            title.English = GetImprovedSkillTitle(title.English, rarity);
            title.French = GetImprovedSkillTitle(title.French, rarity);
            title.German = GetImprovedSkillTitle(title.German, rarity);
            return title;
        }

        private string GetImprovedSkillTitle(string text, RarityName rarity) 
            => $"{text}{RaritySuffix.GetSuffix(rarity)}";
    }
}