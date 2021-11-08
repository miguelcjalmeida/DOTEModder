using System.Collections.Generic;
using Modder.HeroItems.Entities.SimulationDescriptor;

namespace Modder.Skills.Entities
{
    public class SkillDescriptor
    {
        public bool AppliesToTarget { get; set; }
        public IList<ModifierDescriptor> Modifiers { get; set; }

        public string GetType(SkillLevel level)
        {
            if (!AppliesToTarget) return "Skill";
            if (level.IsActive) return "ActiveSkill_Target";
            return "PassiveSkill_Target";
        }

        public string GetIdentifier(Skill skill, SkillLevel level)
        {
            var identifier = level.GetIdentifier(skill);
            if (AppliesToTarget) return $"{identifier}_Target";
            return identifier;
        }
    }
}