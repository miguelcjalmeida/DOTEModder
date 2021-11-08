using System;

namespace Modder.Common.Loaders
{
    public static class EnumParseExtension
    {
        public static T ParseToEnum<T>(this string value) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}