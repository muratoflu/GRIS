using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Generic.CatalogManager
{
    public abstract class CatalogBase
    {
        public CatalogBase()
        {
            LoadCatalog();
        }

        protected virtual void LoadCatalog()
        {
            String typeName = GetCatalogTypeName();

            foreach (PropertyInfo prop in GetPropertyList())
            {
                prop.SetValue(this,
                    CatalogHelpers.LoadCatalog(
                    prop.PropertyType,
                    GetXmlFileName(typeName, prop.Name)));
            }
        }
        protected virtual String GetXmlFileName(string typeName, string p)
        {
            return typeName + "\\" + p + ".xml";
        }

        protected virtual IEnumerable<PropertyInfo> GetPropertyList()
        {
            return this.GetType().GetProperties().ToList();
        }

        protected virtual String GetCatalogTypeName()
        {
            return this.GetType().Name;
        } 
    }
}
