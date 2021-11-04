using Modder;
using Modder.Entities.HeroItem.SimulationDescriptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.WeaponDiverseAttributes
{
    public class ModifierUpgrader
    {
        private static Dictionary<TargetProperty, ModifierLevelUpRange> knownProperties = GetKnownProperties();

        public float GetNextLevelOf(ModifierDescriptor modifier)
        {
            if (!knownProperties.ContainsKey(modifier.TargetProperty)) return 0f;

            var knownProperty = knownProperties[modifier.TargetProperty];
            var nextLevelValue = knownProperty.NextValue();
            if (IsGreatRoll()) nextLevelValue += knownProperty.Min;
            return nextLevelValue;
        }

        private static Dictionary<TargetProperty, ModifierLevelUpRange> GetKnownProperties()
        {
            var types = new Dictionary<TargetProperty, ModifierLevelUpRange>();
            types.Add(TargetProperty.AttackCooldown, new ModifierLevelUpRange(0.01f, 0.02f));
            types.Add(TargetProperty.AttackPower, new ModifierLevelUpRange(3, 5));
            types.Add(TargetProperty.Defense, new ModifierLevelUpRange(1, 3));
            types.Add(TargetProperty.HealthRegen, new ModifierLevelUpRange(1, 2));
            types.Add(TargetProperty.MaxHealth, new ModifierLevelUpRange(10, 20));
            types.Add(TargetProperty.MoveSpeed, new ModifierLevelUpRange(1, 3));
            types.Add(TargetProperty.Wit, new ModifierLevelUpRange(1, 1));
            return types;
        }

        private bool IsGreatRoll()
        {
            return ModRandom.NextFloat(0f, 1f) < 0.3f;
        }
    }

    public class ModifierLevelUpRange
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public RoundToNearest RoundToNearest { get; private set; }

        public ModifierLevelUpRange(float min, float max, RoundToNearest round)
        {
            Min = min;
            Max = max;
            RoundToNearest = round;
        }

        public ModifierLevelUpRange(float min, float max)
        {
            Min = min;
            Max = max;
            RoundToNearest = RoundToNearest.No;
        }

        public ModifierLevelUpRange(int min, int max)
        {
            Min = min;
            Max = max;
            RoundToNearest = RoundToNearest.Yes;
        }

        public float NextValue()
        {
            if (RoundToNearest == RoundToNearest.Yes) return NearestNextValue();
            return NextValueAsFloat();
        }

        public float NearestNextValue()
        {
            var value = ModRandom.NextFloat(Min, Max);
            return (float)Math.Round(value, 0);
        }

        public float NextValueAsFloat()
        {
            var value = ModRandom.NextFloat(Min, Max);
            return (float)Math.Round(value, 2);
        }
    }

    public enum RoundToNearest
    {
        Yes,
        No
    }
}
