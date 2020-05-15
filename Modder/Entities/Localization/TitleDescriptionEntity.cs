namespace Modder.Entities.Localization
{
    public interface TitleDescriptionEntity
    {
        public Description Title { get; }
        public Description Description { get; }
        public string LocalizationTitlePlaceholder { get; }
        public string LocalizationDescriptionPlaceholder { get; } 
    }
}