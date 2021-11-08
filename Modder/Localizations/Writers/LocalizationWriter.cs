using System.Collections.Generic;
using Modder.Common.Writers;
using Modder.Localizations.Entities;

namespace Modder.Localizations.Writers
{
    public class LocalizationWriter : DataTableWriter<IList<Localization>>
    {
        private readonly SingleLanguageLocalizationWriter _englishWriter =
            new SingleLanguageLocalizationWriter("english", description => description.English);

        private readonly SingleLanguageLocalizationWriter _frenchWriter =
            new SingleLanguageLocalizationWriter("french", description => description.French);

        private readonly SingleLanguageLocalizationWriter _germanWriter =
            new SingleLanguageLocalizationWriter("german", description => description.German);

        public void Write(string distPath, IList<Localization> content)
        {
            _englishWriter.Write(distPath, content);
            _frenchWriter.Write(distPath, content);
            _germanWriter.Write(distPath, content);
        }
    }
}