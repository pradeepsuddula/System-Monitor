using ConsoleApp_PoC.SRC_BaseComponents.SRC_Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_PoC.SRC_Components.Utils
{
    public class SRCUtilsSingleton
    {
        // Private static variable that holds the instance of the class
        private static SRCUtilsSingleton _instance;

        // Private constructor to prevent instantiation from outside
        private SRCUtilsSingleton()
        {
            // Initialize any necessary resources here
            Console.WriteLine("Singleton instance created.");
        }

        // Public static property to get the instance
        public static SRCUtilsSingleton Instance
        {
            get
            {
                // If the instance is null, create it (Lazy Initialization)
                if (_instance == null)
                {
                    _instance = new SRCUtilsSingleton();
                }
                return _instance;
            }
        }

        // Sample method to demonstrate usage
        public SRCSystemsEnums ConvertInputToSRCEnums(string inputString)
        {
            Debug.WriteLine("Singleton instance is doing something.");

            if (!string.IsNullOrWhiteSpace(inputString)) {

                if (string.Equals(inputString, SRC_CommonConstants.SRC_OS_Linux, StringComparison.OrdinalIgnoreCase))
                {
                    return SRCSystemsEnums.LINUX;
                }
                else if (string.Equals(inputString, SRC_CommonConstants.SRC_OS_MacOS, StringComparison.OrdinalIgnoreCase)) {
                    return SRCSystemsEnums.MACOS;
                }

                return SRCSystemsEnums.WINDOWS;

            }

            return SRCSystemsEnums.WINDOWS;

        }
    }
}
