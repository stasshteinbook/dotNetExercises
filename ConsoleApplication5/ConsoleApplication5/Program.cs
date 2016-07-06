using Plugins.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPlugin> allPlugins = (new PluginResolver()).GetPluginsWithoutObsolete();
            Console.WriteLine("The following plugins were found:");
            for (int i = 0; i < allPlugins.Count; i++)
            {
                Console.WriteLine($"{i}. Plugin named {allPlugins[i].Name}");
            }
            Console.WriteLine("Type in the id of the plugin:");
            int pluginID = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Invoking plugin with name {allPlugins[pluginID].Name}");
            allPlugins[pluginID].WorkWork();
        }
    }
}
