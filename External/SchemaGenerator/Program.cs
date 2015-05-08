using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchemaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            String CatalogsPath = FindDirectory("Catalog");
            String SchemaPath = FindDirectory("Schema");
            String AssemblyPath = FindDirectory("Generic.Server\\CatalogLibrary");

            String catalogAssembly =
                    Path.Combine(AssemblyPath, "Generic.Catalog.dll");


            var proc = Process.Start(new ProcessStartInfo
            {
                FileName = "SchemaGenerator\\xsd.exe",
                Arguments = catalogAssembly + " /o:\"" + SchemaPath + "\"",
                WindowStyle = ProcessWindowStyle.Hidden, 
                UseShellExecute = false,
                RedirectStandardOutput = true
            });

            proc.OutputDataReceived += proc_OutputDataReceived;
            proc.WaitForExit();
            var exitCode = proc.ExitCode;
            if (exitCode == 0)
            {
                Console.WriteLine("Schema has been generated successfully.");
            }
            else
            {
                Console.WriteLine("Schema could not be generated.");
            }

        }

        static void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
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
