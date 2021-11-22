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
    public class ExtraEnergyCell : Skill
    {
        public ExtraEnergyCell()
        {
            Icon = "GUI/DynamicBitmaps/Events/DustFactory";
            Name = "ExtraEnergyCell";
            Title = new Description
            {
                English = "Extra Energy Cell",
                French = "Cellule d'énergie supplémentaire",
                German = "Extra Energiezelle"
            };
            Description = new Description
            {
                English = "Costs energy, but keeps you alive",
                French = "Coûte de l'énergie, mais vous maintient en vie",
                German = "Kostet Energie, hält aber am Leben"
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
                                    TargetProperty = TargetProperty.MaxHealth,
                                    Operation = Operation.Percent,
                                    Value = .20f,
                                    Path = Path.CurrentHero,
                                },
                            }
                        },
                        new SkillDescriptor
                        {
                            AppliesToTarget = true,
                            Modifiers = new List<ModifierDescriptor>
                            {
                                new ModifierDescriptor
                                {
                                    TargetProperty = TargetProperty.DustLootProbability,
                                    Operation = Operation.Percent,
                                    Value = -0.1f
                                },
                            }
                        },
                    }
                }
            };
        }
    }
}
