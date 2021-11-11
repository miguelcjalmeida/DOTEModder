using Modder.Common.Loaders;
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
            if (value is bool) return value.ToString().ToLower();
            return value.ToString();
        }

        public static T ValueAs<T>(string value)
        {
            var type = typeof(T);
            if (type == typeof(bool)) return (T)(object)Convert.ToBoolean(value.ToLower());
            if (type == typeof(string)) return (T)(object)value;
            if (type == typeof(int)) return (T)(object)Convert.ToInt32(value);
            if (type.IsEnum) return (T)(object)(T)Enum.Parse(typeof(T), value);
            return default;
        }
    }
}
