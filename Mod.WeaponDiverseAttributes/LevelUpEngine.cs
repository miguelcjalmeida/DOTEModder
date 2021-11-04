using Modder;
using Modder.Entities.HeroItem.SimulationDescriptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.WeaponDiverseAttributes
{
    public class LevelUpEngine
    {
        private readonly static ModifierUpgrader upgrader = new ModifierUpgrader();
        private readonly static IList<TargetProperty> levelUpProperties = GetLevelUpProperties();
        private readonly IList<ModifierDescriptor> allModifiers;
        private readonly IList<ModifierDescriptor> enhanceableModifiers;
        private readonly bool areAllModifiersPenalties;

        public LevelUpEngine(IList<ModifierDescriptor> itemModifiers)
        {
            this.allModifiers = itemModifiers;
            this.enhanceableModifiers = itemModifiers.Where(x => levelUpProperties.Contains(x.TargetProperty)).ToList();
            this.areAllModifiersPenalties = enhanceableModifiers.All(x => x.IsPenalty());
        }

        public bool TryToLevelUp()
        {
            if (!CanLevelUp()) return false;
            var nextIndex = ModRandom.Next(0, enhanceableModifiers.Count - 1);
            var nextModifier = enhanceableModifiers[nextIndex];
            var isPenalty = nextModifier.IsPenalty();
            var levelUpValue = upgrader.GetNextLevelOf(nextModifier);

            if (isPenalty) nextModifier.AddPenalty(levelUpValue);
            else nextModifier.AddBonus(levelUpValue);

            return !isPenalty;
        }

        public bool CanLevelUp()
        {
            return !areAllModifiersPenalties;
        }

        private static IList<TargetProperty> GetLevelUpProperties()
        {
            return new List<TargetProperty>
            {
                TargetProperty.AttackCooldown,
                TargetProperty.AttackPower,
                TargetProperty.Defense,
                TargetProperty.HealthRegen,
                TargetProperty.MaxHealth,
                TargetProperty.MoveSpeed,
                TargetProperty.Wit
            };
        }
    }
}
