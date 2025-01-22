using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUAT.Support
{
    public class ADBHelper
    {
        public static string RunADBCommand(string adbCommand)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "adb",
                Arguments = adbCommand,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process
            {
                StartInfo = processStartInfo
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (!string.IsNullOrEmpty(error))
            {
                throw new InvalidOperationException($"ADB command error: {error}");
            }

            return output.Trim();
        }
    }
}
