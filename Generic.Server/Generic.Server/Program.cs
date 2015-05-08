using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Util;
using Generic.Logging;
using Generic.CatalogManager;

namespace Generic.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize Singleton objects
            Initialize();

            //Todo: initialize and test DB access

            //Load predefined values for Services 

            //Test for Console Commands
            Console.ReadKey();
            //Apply new state

            //Uninitialize Singleton objects
            Uninitialize();
        }

        private static void Uninitialize()
        {
            Log.Warn("Unloading Catalogs...");
            Catalogs.DestroySingleton();
            Log.Warn("Done unloading Catalogs.");

            Log.Warn("End of session");
            Log.DestroySingleton();
        }

        private static void Initialize()
        {
            Log.InitSingleton();
            Log.Warn("Server Started");

            Log.Warn("Loading Catalogs...");
            Catalogs.InitSingleton();
            Log.Warn("Done Loading Catalogs.");

        }
    }
}
