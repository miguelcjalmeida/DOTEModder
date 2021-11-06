using Modder.Entities.Ship;
using System.Collections.Generic;

namespace Modder.Writers.Ships
{
    public class ShipWriter : DataTableWriter<IList<Ship>>
    {
        public void Write(string distPath, IList<Ship> items)
        {
            new ShipConfigsWriter().Write(distPath, items);
        }
    }
}
