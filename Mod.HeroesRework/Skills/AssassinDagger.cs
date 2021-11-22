using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System;
using System.Collections.Generic;

namespace Mod.HeroesRework.Skills
{
    public class AssassinDagger : Skill
    {
        public AssassinDagger()
        {
            Icon = "GUI/DynamicBitmaps/Items/Weapon022";
            Name = "AssassinDagger";
            Title = new Description
            {
                English = "Assassin Dagger",
                French = "Dague d'assassin",
                German = "Assassinendolch"
            };
            Description = new Description
            {
                English = "A sharp treacherous knife capable of poisoning",
                French = "Un couteau perfide tranchant capable d'empoisonner",
                German = "Ein scharfes, tückisches Messer, das vergiften kann"
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
                                    TargetProperty = TargetProperty.InflictPoisonChance,
                                    Operation = Operation.Addition,
                                    Value = 5,
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
