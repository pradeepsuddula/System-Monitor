using ConsoleApp_PoC.SRC_BaseComponents.AbstractClasses;
using System.Diagnostics;

internal class CPUMonitoringLibForWindows : SRC_MonitoringAPIsBaseClass
{
    private static PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

    public async Task<float> GetCpuUsageAsync()
    {
        float cpuUsage = cpuCounter.NextValue();
        await Task.Delay(1000);
        return cpuCounter.NextValue();
    }

    // Existing file logging method stays as it is
    public async Task CPUMonitorAPIPlugin()
    {
        string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "cpu_usage_log.txt");
        while (true)
        {
            float cpuUsage = await GetCpuUsageAsync();
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}, {cpuUsage:F2}%";
            await LogToFileAsync(logFilePath, logEntry);
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }

    internal override async Task LogToFileAsync(string logFilePath, string logEntry)
    {
        Console.WriteLine($"[CPU Usage in Windows] Log: {logEntry}");
        await File.AppendAllTextAsync(logFilePath, logEntry + Environment.NewLine);
    }
}
