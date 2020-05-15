namespace Modder.Entities.Localization
{
    public class Description
    {
        public string English { get; set; }
        public string German { get; set; }
        public string French { get; set; }
        
        public override string ToString()
        {
            return English;
        }
    }
}