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
            SetSkillLevels();
        }

        private void SetSkillLevels()
        {
            Levels = new List<SkillLevel>();

            for (var i = 1; i <= 5; i++)
            {
                Levels.Add(new SkillLevel
                {
                    CooldownTurnsCount = 1,
                    Level = i,
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
                                    Value = 1f * i,
                                    Path = Path.CurrentHero,
                                },
                            }
                        }
                    }
                });
            }
        }
    }
}
