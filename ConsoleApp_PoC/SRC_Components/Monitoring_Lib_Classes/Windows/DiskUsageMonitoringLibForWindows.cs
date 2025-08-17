using ConsoleApp_PoC.SRC_BaseComponents.AbstractClasses;

internal class DiskUsageMonitoringLibForWindows : SRC_MonitoringAPIsBaseClass
{
    public Task<long> GetDiskUsedMBAsync()
    {
        DriveInfo drive = new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory));
        long usedMB = (drive.TotalSize - drive.AvailableFreeSpace) / (1024 * 1024);
        return Task.FromResult(usedMB);
    }

    public async Task DiskUsageMonitringAPI()
    {
        string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "disk_usage.txt");
        while (true)
        {
            long usedMB = await GetDiskUsedMBAsync();
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}, Disk Used: {usedMB} MB";
            await LogToFileAsync(logFilePath, logEntry);
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }

    internal override async Task LogToFileAsync(string logFilePath, string logEntry)
    {
        Console.WriteLine($"[Disk Management Usage in Windows] Log: {logEntry}");
        await File.AppendAllTextAsync(logFilePath, logEntry + Environment.NewLine);
    }
}
