using System;
using System.Diagnostics;

namespace PrPM.Utilities
{
    public static class SystemUtils
    {
        public static string RunCommand(string cmd)
        {
            string escapedArgs = cmd.Replace("\"", "\\\"");

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = (Environment.OSVersion.Platform == System.PlatformID.Unix ? "bash" : "cmd"),
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }
}