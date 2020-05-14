using System.Collections.Generic;
using Modder.Item;

namespace Modder.Writers
{
    public class HeroItemWriter : IDataTableWriter<IList<HeroItem>>
    {
        public void Write(string distPath, IList<HeroItem> items)
        {
            new HeroItemConfigsWriter().Write(distPath, items);
            new HeroItemGuiWriter().Write(distPath, items);
            new HeroItemSimulationWriter().Write(distPath, items);
        }
    }
}