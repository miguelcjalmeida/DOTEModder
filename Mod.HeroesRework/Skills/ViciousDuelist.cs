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
    public class ViciousDuelist : Skill
    {
        public ViciousDuelist()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_A0015";
            Name = "Vicious Duelist";
            Title = new Description
            {
                English = "Vicious Duelist",
                French = "Duelliste vicieux",
                German = "Bösartiger Duellant"
            };
            Description = new Description
            {
                English = "No better way to cope with living",
                French = "Il n'y a pas de meilleure façon de faire face à la vie",
                German = "Besser kann man das Leben nicht meistern"
            };
            Levels = new List<SkillLevel>()
            {
                new SkillLevel
                {
                    Level = 1,
                    Descriptors = new List<SkillDescriptor>
                    {
                        new SkillDescriptor
                        {
                            AppliesToTarget = false,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackCooldownBonusWhenTargetedByMob,
                                    Operation = Operation.Addition,
                                    Value = -0.1f,
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
