using System.Collections.Generic;
using Modder.Common.Writers;
using Modder.Heroes.Entities;
using Modder.HeroItems.Entities;

namespace Modder.Heroes.Writers
{
    public class HeroWriter : DataTableWriter<IList<Hero>>
    {
        public void Write(string distPath, IList<Hero> heroes)
        {
            new HeroConfigsWriter().Write(distPath, heroes);
            new HeroLevelConfigsWriter().Write(distPath, heroes);
            new HeroGuiWriter().Write(distPath, heroes);
            new HeroSimulationWriter().Write(distPath, heroes);
        }
    }
}