using Modder.Common;
using Modder.HeroItems.Entities;
using System;

namespace Modder.Heroes.Entities
{
    public class EquipmentSlot
    {
        public EquipmentName Name { get; set; }
        public WeaponType? Type { get; set; }
    }
}