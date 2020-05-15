using System;

namespace Modder
{
    public class Formatter
    {
        public static string FormatNumericValue(float value)
        {
            var roundedValue = (float)Math.Round(value);
            
            if (Math.Abs(value - roundedValue) <= 0.001f) 
                return ((int)value).ToString();
            
            return value.ToString("F1");
        }
    }
}