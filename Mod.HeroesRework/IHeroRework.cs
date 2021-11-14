using Modder.Common.Managers;
using Modder.Heroes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.HeroesRework
{
    public interface IHeroRework
    {
        public string HeroName { get; }
        public void Apply(Hero hero, EntitiesManager manager);
    }
}
