using System;
using System.IO;
using System.Threading;

namespace ModSwitcher
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.Write("Type your folder: ");
            string myFolder = Console.ReadLine();
            string SourceFolder = @"Your folder with folders that have mods" + myFolder;
            string DestinationFolder = @"MODS DIRECTORY";

            if (Directory.Exists(SourceFolder)) { if (Directory.Exists(DestinationFolder)) { } else { Console.WriteLine("Mods folder location doesnt exist!"); Console.ReadKey(); } } else { Console.WriteLine("Your mods folder doesnt exist"); Console.ReadKey(); }

            var files = new DirectoryInfo(SourceFolder).GetFiles("*.*");
            var test = new DirectoryInfo(DestinationFolder).GetFiles("*.*");
            int delFiles = 0;

            foreach (FileInfo file in test)
            {
                file.Delete();
                if (delFiles == SourceFolder.Length) 
                {
                    break;
                }
                else
                {
                    delFiles++;
                }
            } 

            foreach (FileInfo file in files)
            {
                file.CopyTo(DestinationFolder + file.Name);
                if(DestinationFolder.Length == SourceFolder.Length)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (files.Length == test.Length)
            {
                Console.WriteLine(myFolder + " Copy successful!");
                Console.ReadKey(true);
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine(myFolder + " Copy successful!");
                Console.ReadKey(true);
            }
        }
    }
}
