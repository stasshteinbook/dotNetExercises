using Plugins.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooPlugin
{
    [ObsoletePlugin]
    public class FooPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Foo";
            }
        }

        public void WorkWork()
        {
            Console.WriteLine("This is Foo plugin doing work");
        }
    }
}
