using System.Collections.Generic;
using Modder.Entities.Item.SimulationDescriptor;

namespace Modder.Entities.Skill
{
    public class SkillDescriptor
    {
        public bool AppliesToTarget { get; set; }
        public IList<ModifierDescriptor> Modifiers { get; set; }
        public string Type() => AppliesToTarget ? "PassiveSkill_Target" : "Skill";
    }
}