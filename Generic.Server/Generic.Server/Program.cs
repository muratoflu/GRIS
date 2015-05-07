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
            //Test Logging
            Log.InitSingleton();
             
            Log.Trace("A trace");
            Log.Debug("A Debug");
            Log.Info("A Info");
            Log.Warn("A Warn");
            Log.Error("A Error");
            Log.Fatal("A Fatal");


            Console.ReadKey();
            Log.DestroySingleton();
        }
    }
}
