````markdown
# Cross-Platform System Resource Monitor (Windows Implementation)

## Overview
This is a **C# console application** that monitors system resources in real-time and supports a **plugin architecture**.  
It has been implemented primarily for **Windows**, but is structured to support **Linux** and **macOS** in the future.

The application:
- Monitors **CPU usage**, **RAM usage**, and **Disk usage**.
- Periodically logs data to local files.
- Sends collected system metrics to a REST API endpoint in JSON format.
- Uses a factory pattern and clean architecture principles to keep platform-specific code separate.

---

## Features

### System Monitoring
- **CPU Usage (%)** — Collected via `PerformanceCounter`.
- **RAM Usage (MB)** — Calculated as `(Total RAM - Available RAM)`.
- **Disk Usage (MB)** — Collected using `DriveInfo`.

### Plugin Architecture
- **File Logging Plugins**:
  - `CPUMonitoringLibForWindows` → logs CPU usage.
  - `PrivateRAMMonitoringLibForWindows` → logs RAM usage.
  - `DiskUsageMonitoringLibForWindows` → logs Disk usage.
- **API Integration Plugin**:
  - `APIIntegrationPluginForWindows` sends all metrics together in the following JSON format:
    ```json
    {
      "cpu": <cpu_percent>,
      "ram_used": <ram_in_mb>,
      "disk_used": <disk_used_in_mb>
    }
    ```

---

## How It Works

1. **Startup**
   - Application greets the user and asks for a name (demo).
   - `SRC_OS_Factory` determines the OS and returns the matching plugin set.

2. **Execution**
   - For Windows, `SRC_OS_Windows` starts all plugins:
     - CPU → Logs to `cpu_usage_log.txt`
     - RAM → Logs to `ram_usage.txt`
     - Disk → Logs to `disk_usage.txt`
     - API → Sends metrics to the configured API endpoint

3. **Configuration**
   - API URL is currently hardcoded but designed to be configurable via `settings.json`.

---

## Requirements
- **.NET 6 SDK** or later
- **Windows OS** (full functionality in current version)
- Visual Studio 2022 or Visual Studio Code

---

## API Payload Example

```json
{
  "cpu": 12.58,
  "ram_used": 2048.45,
  "disk_used": 512000
}
```
---
```
