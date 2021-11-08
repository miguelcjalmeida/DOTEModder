using System;

namespace Modder.Localizations.Entities
{
    public class Description : ICloneable
    {
        public string English { get; set; }
        public string German { get; set; }
        public string French { get; set; }

        public object Clone()
        {
            var description = new Description();
            description.English = English;
            description.German = German;
            description.French = French;
            return description;
        }

        public override string ToString()
        {
            return English;
        }

        public void AddSuffix(string suffix)
        {
            English += suffix;
            German += suffix;
            French += suffix;
        }
    }
}