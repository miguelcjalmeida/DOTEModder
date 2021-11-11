using System.Collections.Generic;

namespace Modder.Heroes.Entities
{
    public class HeroLevel
    {
        public int Level { get; set; }
        public int FoodCost { get; set; }
        public IList<string> Skills { get; set; }

        public string GetName(string heroName)
        {
            return $"Hero_{heroName}_LVL{Level}";
        }
    }
}