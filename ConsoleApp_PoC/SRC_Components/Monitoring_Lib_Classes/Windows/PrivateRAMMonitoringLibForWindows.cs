using ConsoleApp_PoC.SRC_BaseComponents.AbstractClasses;
using System.Diagnostics;
using System.Management;

internal class PrivateRAMMonitoringLibForWindows : SRC_MonitoringAPIsBaseClass
{
    private PerformanceCounter availableMemoryCounter = new PerformanceCounter("Memory", "Available MBytes");
    private static readonly long totalMemoryBytes = GetTotalMemoryInBytes();

    public Task<float> GetRamUsedMBAsync()
    {
        float availableMemory = availableMemoryCounter.NextValue();
        float usedMemory = (totalMemoryBytes / (1024 * 1024)) - availableMemory;
        return Task.FromResult(usedMemory);
    }

    public async Task PrivateRAMMonitringAPI()
    {
        string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "ram_usage.txt");
        while (true)
        {
            float usedMemory = await GetRamUsedMBAsync();
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}, Used Memory: {usedMemory} MB";
            await LogToFileAsync(logFilePath, logEntry);
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }

    internal override async Task LogToFileAsync(string logFilePath, string logEntry)
    {
        Console.WriteLine($"[Private RAM Usage in Windows] Log: {logEntry}");
        await File.AppendAllTextAsync(logFilePath, logEntry + Environment.NewLine);
    }

    public static long GetTotalMemoryInBytes()
    {
        var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
        foreach (ManagementObject obj in searcher.Get())
            return Convert.ToInt64(obj["TotalVisibleMemorySize"]) * 1024;
        return 0;
    }
}
