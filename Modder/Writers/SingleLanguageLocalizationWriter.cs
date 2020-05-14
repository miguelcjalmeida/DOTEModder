using System;
using System.Collections.Generic;
using System.Xml;

namespace Modder.Writers
{
    public class SingleLanguageLocalizationWriter : DataTableWriter<IList<Localization>>
    {
        private readonly string _languageFolder;
        private readonly Func<Description, string> _getDescriptionText;
        
        public SingleLanguageLocalizationWriter(string languageFolder, Func<Description, string> getDescriptionTextText)
        {
            _languageFolder = languageFolder;
            _getDescriptionText = getDescriptionTextText;
        }
        
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Localization/{_languageFolder}/ED_Localization_Locales.xml";
        
        protected override void WriteContent(XmlWriter writer, IList<Localization> localizations)
            => localizations.ForEach(x => WriteLocalization(writer, x));
        
        private void WriteLocalization(XmlWriter writer, Localization item)
        {
            writer.WriteStartElement("LocalizationPair");
            writer.WriteAttributeString("Name", item.Name);
            writer.WriteValue(_getDescriptionText(item.Description));
            writer.WriteEndElement();
        }
    }
}