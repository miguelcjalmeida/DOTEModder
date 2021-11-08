using System.Collections.Generic;
using Modder.Common.Loaders;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Skills.Entities;

namespace Modder.Skills.Loaders
{
    public class SkillHardcodedLoader : XmlLoader
    {
        private readonly IList<Skill> _skills;

        public SkillHardcodedLoader(IList<Skill> skills)
        {
            _skills = skills;
        }

        public void Populate()
        {
            _skills.Add(new Skill
            {
                HiddenFromConfigurationFile = true,
                Identifier = "Skill_A0010",
                Icon = "GUI/DynamicBitmaps/Skills/Skill_A0010",
                Levels = GetLevels()
            });
        }

        private IList<SkillLevel> GetLevels() => new List<SkillLevel>
        {
            new SkillLevel
            {
                Level = 1,
                Descriptors = GetDescriptors(),
                IsActive = true
            },
            new SkillLevel
            {
                Level = 2,
                Descriptors = GetDescriptors(),
                IsActive = true
            }
        };

        private IList<SkillDescriptor> GetDescriptors() => new List<SkillDescriptor>
        {
            new SkillDescriptor
            {
                AppliesToTarget = false,
                Modifiers = new List<ModifierDescriptor>
                {
                    new ModifierDescriptor
                    {
                        TargetProperty = TargetProperty.Skill_A0010_Effect,
                        Operation = Operation.Addition,
                        Value = 1f,
                        Path = "../Room/Mob"
                    }
                }
            }
        };
    }
}