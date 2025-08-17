using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_PoC.SRC_BaseComponents.AbstractClasses
{
    internal abstract class SRC_MonitoringAPIsBaseClass
    {
        // Abstract method that must be implemented in derived classes
        internal abstract Task LogToFileAsync(string logFilePath, string logEntry);
    }
}
