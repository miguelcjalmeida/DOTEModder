using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Common
{
    public class ModRandom
    {
        public static Random random = new Random();

        public static int Next(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public static float NextFloat(float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }
    }
}
