using System.Collections.Generic;

namespace Modder.Heroes.Entities
{
    public class HeroLevel
    {
        public int Level { get; set; }
        public int FoodCost { get; set; }
        public IList<string> Skills { get; set; }

        public IList<HeroDescriptor> Descriptors { get; set; }

        public string GetIdentifier(string heroName)
        {
            if (Level <= 1) return $"Hero_{heroName}";
            return GetFullIdentifier(heroName);
        }
        public string GetFullIdentifier(string heroName)
        {
            return $"Hero_{heroName}_LVL{Level}";
        }
    }
}