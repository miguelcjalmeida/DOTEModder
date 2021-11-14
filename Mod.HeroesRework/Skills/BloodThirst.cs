using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System.Collections.Generic;

namespace Mod.HeroesRework.Skills
{
    public class BloodThirst : Skill
    {
        public BloodThirst()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_P0011";
            Name = "BloodThirst";
            Title = new Description
            {
                English = "Blood Thirst",
                French = "Soif de sang",
                German = "Blutdurst"
            };
            Description = new Description
            {
                English = "A thirst you can't seem to quench",
                French = "Une soif que tu n'arrives pas à étancher",
                German = "Ein Durst den man scheinbar nicht stillen kann"
            };
            Levels = new List<SkillLevel>()
            {
                new SkillLevel
                {
                    Level = 1,
                    IsActive = false,
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            AppliesToTarget = false,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackPower,
                                    Operation = Operation.Percent,
                                    Value = .05f,
                                    Path = Path.CurrentHero,
                                },
                            }
                        }
                    }
                },
                new SkillLevel
                {
                    Level = 2,
                    IsActive = false,
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            AppliesToTarget = false,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackPower,
                                    Operation = Operation.Percent,
                                    Value = .10f,
                                    Path = Path.CurrentHero,
                                },
                            }
                        }
                    }
                }
            };
        }
    }
}
