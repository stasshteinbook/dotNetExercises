using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Temp";
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;

            watcher.Created += delegate (object sender,FileSystemEventArgs e) 
                { Console.WriteLine("New txt file was created with name: " + e.Name); };
            watcher.EnableRaisingEvents = true;
            watcher.Deleted += (sender, e) => 
                { Console.WriteLine("New txt file was deleted with name: " + e.Name); };
            Console.ReadLine();
        }
    }
}
