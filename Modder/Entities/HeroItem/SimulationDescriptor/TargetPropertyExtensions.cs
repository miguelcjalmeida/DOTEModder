using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Entities.HeroItem.SimulationDescriptor
{
    public static class TargetPropertyExtensions
    {
        public static bool IsTheGreaterTheBetter(this TargetProperty property)
        {
            if (property == TargetProperty.AttackCooldown) return false;
            return true;
        }
    }
}
