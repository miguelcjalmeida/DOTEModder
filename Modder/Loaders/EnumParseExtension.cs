using System;

namespace Modder.Loaders
{
    public static class EnumParseExtension
    {
        public static T ParseToEnum<T>(this string value) where T : Enum
        {
            return (T) System.Enum.Parse(typeof(T), value);
        }
    }
}