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
                French = "Tir à la tête",
                German = "Traf den Kopf"
            };
            Description = new Description
            {
                English = "A dusty ending..",
                French = "Une fin poussiéreuse..",
                German = "Ein staubiges Ende.."
            };
            Levels = new List<SkillLevel>()
            {
                new SkillLevel
                {
                    CooldownTurnsCount = 2,
                    Level = 1,
                    Duration = 0.33f,
                    IsActive = true,
                    TargetVFXPath = "VFX/Skills/FX_Skills_00_Cast",
                    OwnerVFXPath = "VFX/Skills/FX_Skills_00_Cast",
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            AppliesToTarget = true,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.DustLootProbability,
                                    Operation = Operation.Force,
                                    Value = 1f,
                                },
                            }
                        },
                        new SkillDescriptor
                        {
                            AppliesToTarget = false,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackPower,
                                    Operation = Operation.Percent,
                                    Value = 2f,
                                    Path = Path.CurrentHero,
                                },
                            }
                        }
                    }
                },
                new SkillLevel
                {
                    CooldownTurnsCount = 2,
                    Level = 2,
                    Duration = 0.33f,
                    IsActive = true,
                    TargetVFXPath = "VFX/Skills/FX_Skills_00_Cast",
                    OwnerVFXPath = "VFX/Skills/FX_Skills_00_Cast",
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            AppliesToTarget = true,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.DustLootProbability,
                                    Operation = Operation.Force,
                                    Value = 1f,
                                },
                            }
                        },
                        new SkillDescriptor
                        {
                            AppliesToTarget = false,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackPower,
                                    Operation = Operation.Percent,
                                    Value = 4f,
                                    Path = Path.CurrentHero,
                                },
                            }
                        }
                    }
                },
            };
        }
    }
}
