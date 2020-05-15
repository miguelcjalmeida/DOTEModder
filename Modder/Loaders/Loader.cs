using System.Xml;

namespace Modder.Loaders
{
    public abstract class Loader 
    {
        protected XmlDocument LoadDocument(string assetsPath)
        {
            var document = new XmlDocument();
            document.Load(assetsPath);
            return document;
        }
    }
}