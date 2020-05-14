using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Loader;

namespace Modder.Loaders.Localization
{
    public class LocalizationLoader
    {
        public IList<Modder.Localization> LoadFromAssets(string assetsPath)
        {
            var englishDoc = LoadDocument($"{assetsPath}/Localization/english/ED_Localization_Locales.xml");
            var frenchDoc = LoadDocument($"{assetsPath}/Localization/french/ED_Localization_Locales.xml");
            var germanDoc = LoadDocument($"{assetsPath}/Localization/german/ED_Localization_Locales.xml");

            return englishDoc.SelectNodes("Datatable/LocalizationPair")
                .AsQuery()
                .Select(x => CreateLocalization(x, englishDoc, frenchDoc, germanDoc))
                .ToList();
        }

        private static XmlDocument LoadDocument(string assetsPath)
        {
            var heroItemsDoc = new XmlDocument();
            heroItemsDoc.Load(assetsPath);
            return heroItemsDoc;
        }

        private static Modder.Localization CreateLocalization(XmlNode node,
            XmlDocument englishDoc, XmlDocument frenchDoc, XmlDocument germanDoc)
        {
            var name = node.Attributes["Name"].Value;
            var xpath = $"Datatable/LocalizationPair[@Name='{name}']";

            return new Modder.Localization
            {
                Name = node.Attributes["Name"].Value,
                Description = new Description
                {
                    English = englishDoc.SelectSingleNode(xpath).InnerText,
                    French = frenchDoc.SelectSingleNode(xpath).InnerText,
                    German = germanDoc.SelectSingleNode(xpath).InnerText,
                }
            };
        }
    }
}