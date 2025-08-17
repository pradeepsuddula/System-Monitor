using ConsoleApp_PoC.SRC_BaseComponents.SRC_AbstractClasses;
using ConsoleApp_PoC.SRC_Components.Monitoring_Lib_Classes;
using ConsoleApp_PoC.SRC_Components.Monitoring_Lib_Classes.Windows;

namespace ConsoleApp_PoC.SRC_Components.SRC_Factory_Implementations
{
    internal class SRC_OS_Windows : SRC_SystemPluginsBaseClass
    {
        public override async Task StartReadingSystemPlugins()
        {
            var cpuPlugin    = new CPUMonitoringLibForWindows();
            var memoryPlugin = new PrivateRAMMonitoringLibForWindows();
            var diskPlugin   = new DiskUsageMonitoringLibForWindows();

            var apiPlugin = new APIIntegrationPluginForWindows();

            //string apiUrl = "https://example.com/endpoint"; // later read from JSON config
            string apiUrl = "https://webhook.site/d8e9d637-0ac6-4d2e-a926-48c3fabf3bae";

            // Run all plugins concurrently
            var tasks = new Task[]
            {
                cpuPlugin.CPUMonitorAPIPlugin(),
                memoryPlugin.PrivateRAMMonitringAPI(),
                diskPlugin.DiskUsageMonitringAPI(),
                apiPlugin.StartSendingToApiAsync(apiUrl)
            };

            // Wait for all the tasks to complete
            await Task.WhenAll(tasks);
        }
    }
}
