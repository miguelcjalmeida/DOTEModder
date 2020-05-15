namespace Modder.Entities.Item.Rarity
{
    public class ItemRarity
    {
        public RarityName Name { get; set; }
        public DropCriteria DropCriteria { get; set; }

        public string Suffix => Name == RarityName.Common ? "" : $"_{Name}";
    }
}