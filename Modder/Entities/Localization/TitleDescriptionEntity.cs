namespace Modder.Entities.Localization
{
    public interface TitleDescriptionEntity
    {
        public Description Title { get; set; }
        public Description Description { get; set; }
        public string LocalizationTitlePlaceholder { get; }
        public string LocalizationDescriptionPlaceholder { get; } 
    }
}