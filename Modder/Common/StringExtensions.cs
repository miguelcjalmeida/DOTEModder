using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Common
{
    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            if (input == null) return null;
            if (string.IsNullOrWhiteSpace(input)) return input;
            return input[0].ToString().ToUpper() + input[1..];
        }
    }
}
