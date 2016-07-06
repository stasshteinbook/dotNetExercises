using Plugins.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoopPlugin
{
    public class BoopPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Boop!";
            }
        }

        public void WorkWork()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Boop!");
                Thread.Sleep(1000);
            }
            
        }
    }
}
