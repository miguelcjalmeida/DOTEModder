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
    public class LivingBug : Skill
    {
        public LivingBug()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_A0015";
            Name = "LivingBug";
            Title = new Description
            {
                English = "Living Bug",
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
                                    TargetProperty = TargetProperty.Stealth,
                                    Operation = Operation.Addition,
                                    Value = 1,
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
