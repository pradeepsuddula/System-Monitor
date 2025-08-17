using ConsoleApp_PoC.SRC_BaseComponents.SRC_AbstractClasses;
using ConsoleApp_PoC.SRC_BaseComponents.SRC_Enums;
using ConsoleApp_PoC.SRC_BaseComponents.SRC_Interfaces;
using ConsoleApp_PoC.SRC_Components.SRC_Factory_Implementations;
using ConsoleApp_PoC.SRC_Components.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_PoC.SRC_BaseComponents.SRC_Factory
{
    internal class SRC_OS_Factory : ISystemsType
    {
        public SRC_SystemPluginsBaseClass SystemsTypeFun(string input)
        {
            var srcSystemsEnums = SRCUtilsSingleton.Instance.ConvertInputToSRCEnums(input);

            switch (srcSystemsEnums)
            {
                case SRCSystemsEnums.WINDOWS:
                    // Block of code for WINDOWS
                    SRC_SystemPluginsBaseClass widowsObj = new SRC_OS_Windows();
                    return widowsObj;

                case SRCSystemsEnums.LINUX:

                    // Block of code for LINUX
                    //SRC_MonitorPluginsBaseClass linuxObj = new SRC_OS_Linux();
                    //return linuxObj;

                    SRC_SystemPluginsBaseClass widowsObj2 = new SRC_OS_Windows();
                    return widowsObj2;

                case SRCSystemsEnums.MACOS:
                    // Block of code for MACOS
                    //SRC_MonitorPluginsBaseClass macOSObj = new SRC_OS_MacOS();
                    //return macOSObj;

                    SRC_SystemPluginsBaseClass widowsObj3 = new SRC_OS_Windows();
                    return widowsObj3;

                default:
                    // Block of code if no case matches
                    SRC_SystemPluginsBaseClass widowsObj4 = new SRC_OS_Windows();
                    return widowsObj4;
            }

        }
    }
}
