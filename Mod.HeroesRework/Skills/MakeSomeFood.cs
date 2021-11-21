using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.HeroesRework.Skills
{
    public class MakeSomeFood : Skill
    {
        public MakeSomeFood()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_A0016";
            Name = "MakeSomeFood";
            Title = new Description
            {
                English = "Make Some Food",
                French = "Faire de la nourriture",
                German = "Machen Sie etwas Essen"
            };
            Description = new Description
            {
                English = "Retaliates enemies knowing they can be a great source of energy, increasing stacking effects of food, attack, and def per kill",
                French = "Se venge des ennemis sachant qu'ils peuvent être une excellente source d'énergie, augmentant les effets d'empilement",
                German = "Vergeltet Feinde, da sie wissen, dass sie eine großartige Energiequelle sein können und die Stapeleffekte erhöhen"
            };
            Levels = new List<SkillLevel>()
            {
                new SkillLevel
                {
                    Level = 1,
                    IsActive = true,
                    Duration = 16,
                    CooldownTurnsCount = 2,
                    OwnerVFXPath = "VFX/Skills/FX_Skills_00_Cast",
                    TargetSFXPath = "Master/Skill/Paramedic",
                    TargetVFXPath = "VFX/Skills/FX_Skills_16_LastSupper",
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
                                    Operation = Operation.Addition,
                                    Value = 10f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.DefenseBonusPerMobKilled,
                                    Operation = Operation.Multiplication,
                                    Value = 1.5f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.DefenseBonusPerMobKilled_Max,
                                    Operation = Operation.Multiplication,
                                    Value = 1.5f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.DefenseBonusPerMobKilled_TimeMalus,
                                    Operation = Operation.Force,
                                    Value = 0,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackBonusPerMobKilled,
                                    Operation = Operation.Multiplication,
                                    Value = 1.5f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackBonusPerMobKilled_Max,
                                    Operation = Operation.Multiplication,
                                    Value = 1.5f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackBonusPerMobKilled_TimeMalus,
                                    Operation = Operation.Force,
                                    Value = 0,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.FoodBonusPerMobKilled,
                                    Operation = Operation.Multiplication,
                                    Value = 1.5f,
                                    Path = Path.CurrentHero,
                                },
                            }
                        }
                    }
                },
                new SkillLevel
                {
                    Level = 2,
                    IsActive = true,
                    Duration = 16,
                    CooldownTurnsCount = 2,
                    OwnerVFXPath = "VFX/Skills/FX_Skills_00_Cast",
                    TargetSFXPath = "Master/Skill/Paramedic",
                    TargetVFXPath = "VFX/Skills/FX_Skills_16_LastSupper",
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
                                    Operation = Operation.Addition,
                                    Value = 20f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.DefenseBonusPerMobKilled,
                                    Operation = Operation.Multiplication,
                                    Value = 2f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.DefenseBonusPerMobKilled_Max,
                                    Operation = Operation.Multiplication,
                                    Value = 2f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.DefenseBonusPerMobKilled_TimeMalus,
                                    Operation = Operation.Force,
                                    Value = 0,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackBonusPerMobKilled,
                                    Operation = Operation.Multiplication,
                                    Value = 2f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackBonusPerMobKilled_Max,
                                    Operation = Operation.Multiplication,
                                    Value = 2f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackBonusPerMobKilled_TimeMalus,
                                    Operation = Operation.Force,
                                    Value = 0,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.FoodBonusPerMobKilled,
                                    Operation = Operation.Multiplication,
                                    Value = 2f,
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
