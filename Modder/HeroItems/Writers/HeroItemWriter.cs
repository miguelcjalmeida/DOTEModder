using System.Collections.Generic;
using Modder.Common.Writers;
using Modder.HeroItems.Entities;

namespace Modder.HeroItems.Writers
{
    public class HeroItemWriter : DataTableWriter<IList<HeroItem>>
    {
        public void Write(string distPath, IList<HeroItem> items)
        {
            new HeroItemConfigsWriter().Write(distPath, items);
            new HeroItemGuiWriter().Write(distPath, items);
            new HeroItemSimulationWriter().Write(distPath, items);
        }
    }
}