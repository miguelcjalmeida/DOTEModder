using Modder.HeroItems.Entities.Rarity;

namespace Mod.ItemPassiveScaling
{
    public class RaritySuffix
    {
        public static string FormatIdentifier(RarityName rarity)
        {
            if (rarity == RarityName.Common) return "";
            return rarity.ToString();
        }
        
        public static string GetSuffix(RarityName rarity)
        {
            var bonusCount = rarity == RarityName.Common ? 0 :
                rarity == RarityName.Rarity0 ? 1 :
                rarity == RarityName.Rarity1 ? 2 : 3;
            
            var suffix = "";
            for (var i = 0; i < bonusCount; i++) suffix += "+";
            return suffix;
        }
    }
}