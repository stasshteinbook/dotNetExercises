using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Interfaces
{
    public interface IPlugin
    {
        String Name { get; }
        void WorkWork();
    }
}
