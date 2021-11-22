using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System.Collections.Generic;

namespace Mod.HeroesRework.Skills
{
    public class JustDoIt : Skill
    {
        public JustDoIt()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_P0101";
            Name = "JustDoIt";
            Title = new Description
            {
                English = "Just do it!",
                French = "Fais-le",
                German = "Mach es einfach!"
            };
            Description = new Description
            {
                English = "Sometimes reminding others about their chores is necessary",
                French = "Parfois, il est nécessaire de rappeler aux autres leurs tâches",
                German = "Manchmal ist es notwendig, andere an ihre Aufgaben zu erinnern"
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
                                    TargetProperty = TargetProperty.RepairCapacity,
                                    Operation = Operation.Subtraction,
                                    Value = 1f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.RepairCapacity,
                                    Operation = Operation.Addition,
                                    Value = 1f,
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
