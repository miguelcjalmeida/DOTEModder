using System;

namespace Modder.Entities.HeroItem
{
    public class DropCriteria : ICloneable
    {
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public int ProbabilityWeight { get; set; }

        public object Clone()
        {
            var criteria = new DropCriteria();
            criteria.MinLevel = MinLevel;
            criteria.MaxLevel = MaxLevel;
            criteria.ProbabilityWeight = ProbabilityWeight;
            return criteria;
        }
    }
}