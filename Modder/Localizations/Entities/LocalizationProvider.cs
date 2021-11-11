using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modder.Localizations.Entities
{
    public class LocalizationProvider
    {
        private IList<Localization> _localizations;
        private Dictionary<string, Localization> _localizationByName;

        public LocalizationProvider(IList<Localization> localizations)
        {
            _localizations = localizations;
            _localizationByName = _localizations.ToDictionary(x => x.Name);
        }

        public Localization Get(string name)
        {
            return _localizationByName[name];
        }
    }
}
