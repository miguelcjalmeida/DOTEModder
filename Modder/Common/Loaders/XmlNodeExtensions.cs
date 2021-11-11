using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Modder.Common.Loaders
{
    public static class XmlNodeExtensions
    {
        public static T Attribute<T>(this XmlNode node, string name)
        {
            return XmlTranslation.ValueAs<T>(node.Attributes[name]?.Value);
        }

        public static string Attribute(this XmlNode node, string name)
        {
            return node.Attribute<string>(name);
        }

        public static IList<T> Select<T>(this XmlNode node, Func<XmlNode, T> eachItemCallback)
        {            
            return node.ChildNodes.AsQuery().Select(eachItemCallback).ToList();
        }

        public static IList<T> Select<T>(this XmlNode node, string xpath, Func<XmlNode, T> eachItemCallback)
        {
            return node.SelectNodes(xpath).AsQuery().Select(eachItemCallback).ToList();
        }

        public static IList<T> Select<T>(this XmlDocument doc, string xpath, Func<XmlNode, T> eachItemCallback)
        {
            return doc.SelectNodes(xpath).AsQuery().Select(eachItemCallback).ToList();
        }
    }
}
