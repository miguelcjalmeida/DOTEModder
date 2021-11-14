using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System.Collections.Generic;

namespace Mod.HeroesRework.Skills
{
    public class Headshot : Skill
    {
        public Headshot()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_A0008";
            Name = "Headshot";
            Title = new Description
            {
                English = "Headshot",
                French = "Photo du visage",
                German = "Kopfschuss"
            };
            Description = new Description
            {
                English = "Aim long enough to shoot on the face",
                French = "Visez assez longtemps pour tirer sur le visage",
                German = "Zielen Sie lange genug, um ins Gesicht zu schießen"
            };
            Levels = new List<SkillLevel>()
            {
                new SkillLevel
                {
                    CooldownTurnsCount = 0,
                    Level = 1,
                    Duration = 3,
                    IsActive = true,
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackPower,
                                    Operation = Operation.Percent,
                                    Value = 2,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackCooldown,
                                    Operation = Operation.Force,
                                    Value = 3,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackRange,
                                    Operation = Operation.Force,
                                    Value = 15,
                                    Path = Path.CurrentHero,
                                }
                            }
                        }
                    }
                },
                new SkillLevel
                {
                    CooldownTurnsCount = 0,
                    Level = 2,
                    Duration = 3,
                    IsActive = true,
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackPower,
                                    Operation = Operation.Percent,
                                    Value = 3,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackCooldown,
                                    Operation = Operation.Force,
                                    Value = 3,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackRange,
                                    Operation = Operation.Force,
                                    Value = 15,
                                    Path = Path.CurrentHero,
                                }
                            }
                        }
                    }
                },
            };
        }
    }
}
