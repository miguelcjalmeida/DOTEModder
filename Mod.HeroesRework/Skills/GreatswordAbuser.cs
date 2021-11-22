﻿using Modder.Common;
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
    public class GreatswordAbuser : Skill
    {
        public GreatswordAbuser()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_A0015";
            Name = "GreatswordAbuser";
            Title = new Description
            {
                English = "Greatsword Abuser",
                French = "Insecte vivant",
                German = "Lebender Käfer"
            };
            Description = new Description
            {
                English = "You've been crawling so long no one notices your human attributes",
                French = "Tu rampes depuis si longtemps que personne ne remarque plus tes attributs humains",
                German = "Du krabbelst schon so lange, dass niemand mehr deine menschlichen Eigenschaften bemerkt"
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
                                    Value = .75f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackCooldown,
                                    Operation = Operation.Multiplication,
                                    Value = 1.75f,
                                    Path = Path.CurrentHero,
                                },
                            }
                        },
                    }
                }
            };
        }
    }
}