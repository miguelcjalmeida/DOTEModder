using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Modder.Common.Writers
{
    public static class XmlWriterExtensions
    {
        public static void WriteOptionalAttribute<T>(this XmlWriter writer, string attribute, T value)
        {
            if (value == null) return;

            string printText = value.ToString();
            if (value is bool) printText = printText.ToLower();

            writer.WriteAttributeString(attribute, printText);
        }
    }
}
