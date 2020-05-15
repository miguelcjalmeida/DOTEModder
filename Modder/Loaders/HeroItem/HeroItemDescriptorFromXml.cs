using Modder.Entities.Item.SimulationDescriptor;

namespace Modder.Loaders.HeroItem
{
    public class HeroItemDescriptorFromXml : HeroItemDescriptor
    {
        public string Type { get; set; }
        public string ParentType { get; set; }
    }
}