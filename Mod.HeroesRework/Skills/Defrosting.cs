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
    public class Defrosting : Skill
    {
        public Defrosting()
        {
            Icon = "GUI/DynamicBitmaps/Items/Special036";
            Name = "Defrosting";
            Title = new Description
            {
                English = "Defrosting",
                French = "Décongélation",
                German = "Auftauen"
            };
            Description = new Description
            {
                English = "Great, the sun is out",
                French = "Super, le soleil est de sortie",
                German = "Super, die Sonne scheint"
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
                                    TargetProperty = TargetProperty.InstantDamageOverTime,
                                    Operation = Operation.Addition,
                                    Value = (float)Math.Round(9f + i * 43f/5f, 0),
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
