using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Modder.Loaders
{
    public static class  XmlNodeListExtension
    {
        public static IEnumerable<XmlNode> AsQuery(this XmlNodeList list)
        {
            return list.Cast<XmlNode>();
        }
    }
}