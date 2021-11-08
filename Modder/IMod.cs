using Modder.Common.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder
{
    public interface IMod
    {
        void Apply(EntitiesManager manager);
    }
}
