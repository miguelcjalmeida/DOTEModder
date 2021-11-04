using Modder.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Mod
{
    public interface IMod
    {
        void Apply(EntitiesManager manager);
    }
}
