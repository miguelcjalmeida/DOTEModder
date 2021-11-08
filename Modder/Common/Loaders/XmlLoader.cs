using System.Collections.Generic;
using System.Xml;

namespace Modder.Common.Loaders
{
    public abstract class XmlLoader
    {
        protected XmlDocument LoadDocument(string assetsPath)
        {
            var document = new XmlDocument();
            document.Load(assetsPath);
            return document;
        }
    }
}