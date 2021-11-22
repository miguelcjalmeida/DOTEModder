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
    public class IceBlock : Skill
    {
        public IceBlock()
        {
            Icon = "GUI/DynamicBitmaps/Events/Artifact";
            Name = "IceBlock";
            Title = new Description
            {
                English = "Ice Block",
                French = "Bloc de glace",
                German = "Eisblock"
            };
            Description = new Description
            {
                English = "Put yourself in stasis to restore your true self.. or who you are now",
                French = "Mettez-vous en stase pour restaurer votre vrai moi.. ou qui vous êtes maintenant",
                German = "Versetze dich in Stase, um dein wahres Selbst wiederherzustellen.. oder wer du jetzt bist"
            };
            ConfigureLevels();
        }

        private void ConfigureLevels()
        {
            Levels = new List<SkillLevel>() {
                new SkillLevel
                {
                    Level = 1,
                    IsActive = true,
                    CooldownTurnsCount = 0,
                    Duration = 8,
                    OwnerSFXPath = "Master/Skill/Crawler",
                    OwnerVFXPath = "VFX/Skills/FX_Skills_15_Crawler",
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            AppliesToTarget = false,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.HealthRegen,
                                    Operation = Operation.Addition,
                                    Value = 300,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.Invincible,
                                    Operation = Operation.Addition,
                                    Value = 1,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackCooldown,
                                    Operation = Operation.Force,
                                    Value = 0,
                                    Path = Path.CurrentHero
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.Stealth,
                                    Operation = Operation.Force,
                                    Value = 1,
                                    Path = Path.CurrentHero
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.MoveSpeedReal,
                                    Operation = Operation.Force,
                                    Value = 0,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.HealFoodCostCoeff,
                                    Operation = Operation.Force,
                                    Value = 0,
                                    Path = Path.CurrentHero
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
