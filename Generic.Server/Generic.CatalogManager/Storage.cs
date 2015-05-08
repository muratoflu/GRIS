using Generic.Util;
using Generic.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Generic.CatalogManager
{
    public class Storage : CatalogBase 
    {
        public PaperTypes PaperTypes { get; private set; }
    }
}
