using System;

namespace Modder.Entities.HeroItem.Rarity
{
    public class ItemRarity : ICloneable
    {
        public RarityName Name { get; set; }
        public DropCriteria DropCriteria { get; set; }

        public string Suffix => Name == RarityName.Common ? "" : $"_{Name}";

        public object Clone()
        {
            var rarity = new ItemRarity();
            rarity.Name = Name;
            rarity.DropCriteria = (DropCriteria)DropCriteria?.Clone();
            return rarity;
        }

        public int Level
        {
            get
            {
                if (Name == RarityName.Common) return 0;
                if (Name == RarityName.Rarity0) return 1;
                if (Name == RarityName.Rarity1) return 2;
                if (Name == RarityName.Rarity2) return 3;
                return 4;
            }
        }
    }
}