using Modder.Entities.HeroItem.SimulationDescriptor;

namespace Modder.Loaders.HeroItems
{
    public class HeroItemDescriptorFromXml : HeroItemDescriptor
    {
        public string Type { get; set; }
        public string ParentType { get; set; }
    }
}