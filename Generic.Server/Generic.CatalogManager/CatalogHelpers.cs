using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Generic.CatalogManager
{
    public static class CatalogHelpers
    {
        private static String catalogPath = FindDirectory("Catalog");

        private static XmlSerializer GetSerializer<TItem>()
        {
            return new XmlSerializer(typeof(TItem));
        }

        public static TItem LoadCatalog<TItem>(string fileName)
        {
            Type t = typeof(TItem);
            return (TItem)LoadCatalog(t, fileName);
        }

        public static object LoadCatalog(Type type, string fileName)
        {
            XmlSerializer serializer = null;
            Stream file = null;
            object item;

            try
            {
                serializer = new XmlSerializer(type);

                file =
                    File.OpenRead(
                        Path.Combine(catalogPath, fileName));
            }
            catch (Exception ex)
            {
                Logging.Log.Error(ex);
                throw;
            }
            finally
            {
                try
                {
                    item = serializer.Deserialize(file);
                }
                catch (Exception ex)
                {
                    Logging.Log.Error(ex);
                    throw;
                }
            }

            Logging.Log.Trace("Loaded " + type.Name);

            return item;
        }

        private static string FindDirectory(string p)
        {
            // attempt to find the data directory in a couple different places...
            var dirsToCheck = new[]
            {
                Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", p),
                Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", p),
                Path.Combine(Directory.GetCurrentDirectory(), @"..\..\", p),
                Path.Combine(Directory.GetCurrentDirectory(), @"..\", p),
                Path.Combine(Directory.GetCurrentDirectory(), @"", p),
            };

            foreach (string dir in dirsToCheck)
            {
                if (Directory.Exists(dir))
                {
                    // normalize the path without the ..'s
                    return new DirectoryInfo(dir).FullName;
                }
            }

            return null;
        }
    }
}
