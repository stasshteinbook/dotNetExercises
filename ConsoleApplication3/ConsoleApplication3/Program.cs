using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Trace.WriteLine("Boop");
                Thread.Sleep(1000);
            }
        }
    }
}
