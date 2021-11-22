using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System.Collections.Generic;

namespace Mod.HeroesRework.Skills
{
    public class TasteForPain : Skill
    {
        public TasteForPain()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_A0011";
            Name = "TasteForPain";
            Title = new Description
            {
                English = "Taste for Pain",
                French = "Goût de la douleur",
                German = "Geschmack für Schmerz"
            };
            Description = new Description
            {
                English = "Being hurt and causing others to suffer makes you stronger",
                French = "Être blessé et faire souffrir les autres vous rend plus fort",
                German = "Verletzt zu werden und andere leiden zu lassen, macht dich stärker"
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
                                    TargetProperty = TargetProperty.AttackBonusPerMobKilled,
                                    Operation = Operation.Force,
                                    Value = 1f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackBonusPerMobKilled_Max,
                                    Operation = Operation.Addition,
                                    Value = 999f,
                                    Path = Path.CurrentHero,
                                },
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.AttackBonusPerMobKilled_TimeMalus,
                                    Operation = Operation.Force,
                                    Value = 0f,
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
