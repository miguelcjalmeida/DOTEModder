using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System.Collections.Generic;

namespace Mod.HeroesRework.Skills
{
    public class Deadeye : Skill
    {
        public Deadeye()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_P0011";
            Name = "Deadeye";
            Title = new Description
            {
                English = "Deadeye",
                French = "œil mort",
                German = "Totes Auge"
            };
            Description = new Description
            {
                English = "Load special bullet. Focus. Mark. Draw",
                French = "Chargez une balle spéciale. Se concentrer. Marque. Dessiner",
                German = "Spezialgeschoss laden. Fokus. Markierung. Zeichnen"
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
