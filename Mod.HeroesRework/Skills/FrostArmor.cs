using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;
using Modder.Skills.Entities;
using System;
using System.Collections.Generic;

namespace Mod.HeroesRework.Skills
{
    public class FrostArmor : Skill
    {
        public FrostArmor()
        {
            Icon = "GUI/DynamicBitmaps/Items/Special003";
            Name = "FrostArmor";
            Title = new Description
            {
                English = "Frost Armor",
                French = "Armure de givre",
                German = "Frostrüstung"
            };
            Description = new Description
            {
                English = "The privileges of thick ice",
                French = "Les privilèges de la glace épaisse",
                German = "Die Privilegien des dicken Eises"
            };
            ConfigureLevels();
        }

        private void ConfigureLevels()
        {
            Levels = new List<SkillLevel>();

            for (var i = 1; i <= 5; i++) 
            { 
                var level = new SkillLevel
                {
                    Level = i,
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
                                    TargetProperty = TargetProperty.Defense,
                                    Operation = Operation.Addition,
                                    Value = (float)Math.Round(i * 35f / 5f, 0),
                                    Path = Path.CurrentHero,
                                }, 
                            }
                        }
                    }
                };

                Levels.Add(level);
            }
        }
    }
}
