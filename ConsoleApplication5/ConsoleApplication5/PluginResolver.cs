using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugins.Interfaces;
using System.Reflection;
using System.IO;

namespace ConsoleApplication5
{
    public class PluginResolver
    {
        private List<RuntimeTypeHandle> cachedPluginTypes;
        public List<IPlugin> GetPlugins()
        {
            List<IPlugin> result = new List<IPlugin>();
            if (cachedPluginTypes!= null)
            {
                foreach (var pluginType in cachedPluginTypes)
                {
                    result.Add(Activator.CreateInstance(Type.GetTypeFromHandle(pluginType)) as IPlugin);
                }
                return result;
            }

            
            String rootPath =  Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            String pluginPath = Path.Combine(rootPath, "Plugins");
            var assembliesInPLugins = Directory.GetFiles(pluginPath, "*.dll", SearchOption.TopDirectoryOnly);
            foreach (var pluginAssembly in assembliesInPLugins)
            {
                try
                {
                    var assembly = Assembly.LoadFile(pluginAssembly);
                    var allTypes = assembly.GetTypes().Where(x => typeof(IPlugin).IsAssignableFrom(x));
                    this.cachedPluginTypes = allTypes.Select(x => x.TypeHandle).ToList();
                    foreach (var pluginType in allTypes)
                    {
                        result.Add(Activator.CreateInstance(pluginType) as IPlugin);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Warning - {pluginAssembly} was not a valid .net assembly in plugins directory!"); ;
                }
            }
            return result;
        }

        public List<IPlugin> GetPluginsWithoutObsolete()
        {
            List<IPlugin> result = new List<IPlugin>();
            String rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            String pluginPath = Path.Combine(rootPath, "Plugins");
            var assembliesInPLugins = Directory.GetFiles(pluginPath, "*.dll", SearchOption.TopDirectoryOnly);
            foreach (var pluginAssembly in assembliesInPLugins)
            {
                try
                {
                    var assembly = Assembly.LoadFile(pluginAssembly);
                    var allTypes = assembly.GetTypes().Where(x => typeof(IPlugin).IsAssignableFrom(x));
                    allTypes = allTypes.Where(x => !x.IsDefined(typeof(ObsoletePluginAttribute)));
                    foreach (var pluginType in allTypes)
                    {
                        result.Add(Activator.CreateInstance(pluginType) as IPlugin);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Warning - {pluginAssembly} was not a valid .net assembly in plugins directory!"); ;
                }
            }
            return result;
        }
    }
}
