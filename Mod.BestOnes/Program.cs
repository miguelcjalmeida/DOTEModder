using Mod.ItemPassiveScaling;
using Mod.RandomSort;
using Mod.WeaponDiverseAttributes;
using Modder;
using System.Collections.Generic;

namespace Mod.BestOnes
{
    class Program
    {
        static void Main(string[] args)
        {
            var modRunner = new Runner();
            modRunner.Run(new List<IMod>()
            {
                //new ItemPassiveScalingMod(),
                //new DiverseAttributesMod(),
                //new RandomSortMod(),
                new TestMod(),
            });
        }
    }
}
