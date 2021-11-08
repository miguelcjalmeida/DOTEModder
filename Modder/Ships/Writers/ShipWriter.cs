using Modder.Common.Writers;
using Modder.Ships.Entities;
using System.Collections.Generic;

namespace Modder.Ships.Writers
{
    public class ShipWriter : DataTableWriter<IList<Ship>>
    {
        public void Write(string distPath, IList<Ship> items)
        {
            new ShipConfigsWriter().Write(distPath, items);
        }
    }
}
