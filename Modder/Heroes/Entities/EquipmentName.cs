using Modder.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Heroes.Entities
{
    public enum EquipmentName
    {
        Weapon,
        Armor,
        Special
    }

    public static class EquipmentNameExtensions
    {
        private static Map<string, EquipmentName> mapping = CreateMapping();
        public static string AsText(this EquipmentName path)
        {
            if (mapping.Backward.ContainsKey(path)) return mapping.Backward[path];
            throw new Exception($"Path don't exists {path.ToString()}");
        }

        public static EquipmentName AsEquipmentName(this string value)
        {
            if (mapping.Forward.ContainsKey(value)) return mapping.Forward[value];
            throw new Exception($"Path don't exists '{value}'");
        }

        private static Map<string, EquipmentName> CreateMapping()
        {
            var mapping = new Map<string, EquipmentName>();
            mapping.Add("ItemHero_Weapon", EquipmentName.Weapon);
            mapping.Add("ItemHero_Armor", EquipmentName.Armor);
            mapping.Add("ItemHero_Special", EquipmentName.Special);
            return mapping;
        }

    }
}
