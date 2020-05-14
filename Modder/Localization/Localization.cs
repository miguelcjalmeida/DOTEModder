namespace Modder
{
    public class Localization
    {
        public string Name { get; set; }
        public Description Description { get; set; }
        
        public Localization() {}

        public Localization(string name, Description description)
        {
            Name = name;
            Description = description;
        }
    }
}