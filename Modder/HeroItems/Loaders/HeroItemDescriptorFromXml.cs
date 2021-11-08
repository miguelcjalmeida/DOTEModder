using Modder.HeroItems.Entities.SimulationDescriptor;

namespace Modder.HeroItems.Loaders
{
    public class HeroItemDescriptorFromXml : HeroItemDescriptor
    {
        public string Type { get; set; }
        public string ParentType { get; set; }
    }
}