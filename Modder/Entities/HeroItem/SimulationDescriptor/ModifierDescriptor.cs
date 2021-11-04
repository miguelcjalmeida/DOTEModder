using System;

namespace Modder.Entities.HeroItem.SimulationDescriptor
{
    public class ModifierDescriptor : ICloneable
    {
        public TargetProperty TargetProperty;
        public Operation Operation;
        public float Value;
        public string Path;

        public object Clone()
        {
            var descriptor = new ModifierDescriptor();
            descriptor.TargetProperty = TargetProperty;
            descriptor.Operation = Operation;
            descriptor.Value = Value;
            descriptor.Path = Path;
            return descriptor;
        }

        public bool IsPenalty()
        {
            var apperantlyPenalty = TargetProperty.IsTheGreaterTheBetter() ? Value < 0f : Value > 0f;
            if (Operation == Operation.Subtraction) return !apperantlyPenalty;
            return apperantlyPenalty;
        }

        public void AddPenalty(float value)
        {
            AddBonus(-value);
        }

        public void AddBonus(float value)
        {
            if (TargetProperty.IsTheGreaterTheBetter() && Operation != Operation.Subtraction) 
                Value += value;
            else if (TargetProperty.IsTheGreaterTheBetter() && Operation == Operation.Subtraction) 
                Value -= value;
            else if (Operation == Operation.Subtraction) 
                Value += value;
            else 
                Value -= value;
        }
    }
}