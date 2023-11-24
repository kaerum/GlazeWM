using System;
using System.Management;
using System.Diagnostics;

namespace GlazeWM.Infrastructure.Utils {
  public static class ProcessExtensions {

    public static String ProcessCommandLine(this Process process) {
      try {
        var query = "SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id;
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query)) {
          using (ManagementObjectCollection objects = searcher.Get()) {
            foreach(ManagementBaseObject @object in objects) {
              return @object["CommandLine"].ToString();
            }
          }
        }
      } catch (Exception) {}
      return "";
    }
  }
}
