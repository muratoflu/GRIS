using Generic.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.CatalogManager
{
    public class Catalogs : Singleton<Catalogs>
    {
        public Storage Storage { get; private set; }

        public Catalogs()
        {
            Storage = new Storage();
        }
    }
}
