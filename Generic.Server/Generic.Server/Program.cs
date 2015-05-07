using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Util;
using Generic.Logging; 

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
            Log.Info("Deneme");
            //Apply new state
            
            //Uninitialize Singleton objects
            Uninitialize();
        }

        private static void Uninitialize()
        {
            Log.DestroySingleton();
        }

        private static void Initialize()
        {
            Log.InitSingleton();
        }
    }
}
