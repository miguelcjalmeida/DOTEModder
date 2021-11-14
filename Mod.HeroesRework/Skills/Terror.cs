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
    public class Terror : Skill
    {
        public Terror()
        {
            Icon = "GUI/DynamicBitmaps/Skills/Skill_A0008";
            Name = "Terror";
            Title = new Description
            {
                English = "Terror",
                French = "Terror",
                German = "Terror"
            };
            Description = new Description
            {
                English = "Lights off!",
                French = "Lights off!",
                German = "Lights off!"
            };

            CreateTerrorVersions();
        }

        private void CreateTerrorVersions()
        {
            Levels = new List<SkillLevel>();

            for (var i = 1; i <= 9; i++)
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
                                    TargetProperty = TargetProperty.UnpoweredRoomAttackPowerBonus,
                                    Operation = Operation.Addition,
                                    Value = 32f + i * 4f,
                                    Path = Path.CurrentHero
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
