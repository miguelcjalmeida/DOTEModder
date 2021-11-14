using Modder;
using Modder.Common;
using Modder.Common.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.BestOnes
{
    public class TestMod : IMod
    {
        public void Apply(EntitiesManager manager)
        {
            var heroes = manager.HeroManager.Stored;
            heroes.ForEach(x => x.Title.AddSuffix("s"));
        }
    }
}
