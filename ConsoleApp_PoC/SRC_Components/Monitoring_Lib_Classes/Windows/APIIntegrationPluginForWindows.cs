using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp_PoC.SRC_Components.Monitoring_Lib_Classes.Windows
{
    internal class APIIntegrationPluginForWindows
    {
        private readonly CPUMonitoringLibForWindows cpuLib = new CPUMonitoringLibForWindows();
        private readonly PrivateRAMMonitoringLibForWindows ramLib = new PrivateRAMMonitoringLibForWindows();
        private readonly DiskUsageMonitoringLibForWindows diskLib = new DiskUsageMonitoringLibForWindows();
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task StartSendingToApiAsync(string apiUrl)
        {
            while (true)
            {
                float cpu = await cpuLib.GetCpuUsageAsync();
                float ram = await ramLib.GetRamUsedMBAsync();
                long disk = await diskLib.GetDiskUsedMBAsync();

                var payload = new { cpu, ram_used = ram, disk_used = disk };

                Console.WriteLine($"APIIntegrationPluginForWindows [API] payload: {payload}");

                string json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PostAsync(apiUrl, content);
                    Console.WriteLine(response.IsSuccessStatusCode
                        ? $"[API] Sent: {json}"
                        : $"[API] Failed: {response.StatusCode}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[API] Error: {ex.Message}");
                }

                await Task.Delay(TimeSpan.FromMinutes(1));
                //await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}
