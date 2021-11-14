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
    public class ShowYourself : Skill
    {
        public ShowYourself()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_A0015";
            Name = "ShowYourself";
            Title = new Description
            {
                English = "Show Yourself",
                French = "Montre toi",
                German = "Zeige dich"
            };
            Description = new Description
            {
                English = "You make a huge effort to draw attention to yourself",
                French = "Vous faites un gros effort pour attirer l'attention sur vous",
                German = "Du gibst dir viel Mühe, auf dich aufmerksam zu machen"
            };
            Levels = new List<SkillLevel>()
            {
                new SkillLevel
                {
                    Level = 1,
                    IsActive = true,
                    Duration = 3,
                    CooldownTurnsCount = 0,
                    OwnerSFXPath = "Master/Skill/Crawler",
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            AppliesToTarget = false,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.Stealth,
                                    Operation = Operation.Force,
                                    Value = 0,
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
                    Duration = 3,
                    CooldownTurnsCount = 0,
                    OwnerSFXPath = "Master/Skill/Crawler",
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            AppliesToTarget = false,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.Stealth,
                                    Operation = Operation.Force,
                                    Value = 0,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.MobsAggro,
                                    Operation = Operation.Addition,
                                    Value = 1,
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
