using System.Collections.Generic;

namespace Modder.Entities.Skill
{
    public class SkillLevel
    {
        public int Level { get; set; }
        public bool IsActive { get; set; }
        public float Duration { get; set; }
        public float CooldownTurnsCount { get; set; }
        public string DialogVFXPath { get; set; }
        public string TargetVFXPath { get; set; }
        public string TargetSFXPath { get; set; }
        public string OwnerVFXPath { get; set; }
        public string OwnerSFXPath { get; set; }
        public string DamagesTargetsPath { get; set; }
        public bool DeactivateOnNewTurn { get; set; }
        public IList<SkillDescriptor> Descriptors { get; set; }
        
        public string GetIdentifier(Skill skill)
        {
            if (Level <= 1) return skill.Identifier;
            return $"{skill.Identifier}_LVL{Level}";
        }
    }
}