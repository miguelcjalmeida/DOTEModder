using Mod.HeroesRework;
using Mod.ItemPassiveScaling;
using Mod.RandomSort;
using Mod.WeaponDiverseAttributes;
using Modder;
using Modder.Common;
using System.Collections.Generic;

namespace Mod.BestOnes
{
    class Program
    {
        static void Main(string[] args)
        {
            ModRandom.Seed(19931234);
            var modRunner = new Runner();
            modRunner.Run(new List<IMod>()
            {
                new ItemPassiveScalingMod(),
                new DiverseAttributesMod(),
                new RandomSortMod(),
                new HeroesReworkMod(),
            });
        }
    }
}
