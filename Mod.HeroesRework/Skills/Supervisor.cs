using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System;
using System.Collections.Generic;

namespace Mod.HeroesRework.Skills
{
    public class Supervisor : Skill
    {
        public Supervisor()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_P0102";
            Name = "Supervisor";
            Title = new Description
            {
                English = "Supervisor",
                French = "Superviseur",
                German = "Supervisor"
            };
            Description = new Description
            {
                English = "They know I am always around",
                French = "Ils savent que je suis toujours là",
                German = "Sie wissen, dass ich immer da bin"
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
                                    TargetProperty = TargetProperty.Wit,
                                    Operation = Operation.Multiplication,
                                    Value = (float)Math.Round(1/1.75f, 2),
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.Wit,
                                    Operation = Operation.Percent,
                                    Value = .75f,
                                    Path = Path.HeroesInRoom,
                                },
                            }
                        }
                    }
                },
            };
        }
    }
}
