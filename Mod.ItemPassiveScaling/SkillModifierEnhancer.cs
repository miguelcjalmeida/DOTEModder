using Modder.HeroItems.Entities.SimulationDescriptor;

namespace Mod.ItemPassiveScaling
{
    public class SkillModifierEnhancer
    {
        private readonly float _bonus = .375f;
        public void Enhance(int rarityLevel, ModifierDescriptor modifier)
        {
            if (modifier.Operation == Operation.Force) return;
            modifier.Value += modifier.Value * rarityLevel * _bonus;
        }
    }
}