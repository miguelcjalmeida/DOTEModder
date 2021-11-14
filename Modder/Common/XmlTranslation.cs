using Modder.Common.Loaders;
using Modder.Heroes.Entities;
using Modder.Localizations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Common
{
    public class XmlTranslation
    {
        public static string AsText<T>(T value)
        {
            if (value == null) return "";
            if (value is Localization) return ((Localization)(object)value).Name;
            if (value is bool) return value.ToString().ToLower();
            if (value is Path) return ((Path)(object)value).AsText();
            if (value is EquipmentName) return ((EquipmentName)(object)value).AsText();
            return value.ToString();
        }

        public static T ValueAs<T>(string value)
        {
            if (value == null) return default;
            var type = typeof(T);
            if (type == typeof(bool)) return (T)(object)Convert.ToBoolean(value.ToLower());
            if (type == typeof(string)) return (T)(object)value;
            if (type == typeof(int)) return (T)(object)Convert.ToInt32(value);
            if (type == typeof(Path)) return (T)(object)value.AsPath();
            if (type == typeof(EquipmentName)) return (T)(object)value.AsEquipmentName();
            if (type.IsEnum) return (T)(object)(T)Enum.Parse(typeof(T), value);
            if (Nullable.GetUnderlyingType(type) != null)
            {
                var notNullableType = Nullable.GetUnderlyingType(type);
                var method = typeof(XmlTranslation).GetMethod(nameof(ValueAs)).MakeGenericMethod(notNullableType);
                return (T)method.Invoke(null, new object[] { value });
            }
            return default;
        }
    }
}
