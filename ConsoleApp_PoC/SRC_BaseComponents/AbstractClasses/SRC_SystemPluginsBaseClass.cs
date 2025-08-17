using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_PoC.SRC_BaseComponents.SRC_AbstractClasses
{
    internal abstract class SRC_SystemPluginsBaseClass
    {
        // Abstract method that must be implemented in derived classes
        public abstract Task StartReadingSystemPlugins();
    }
}
