using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUAT.Support
{
    public class CommandHelper
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

        public static string RunLaunchEmulatorPowershellScript(string scriptPath, string avdName)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\" -avdName \"{avdName}\"",
                UseShellExecute = true,
                CreateNoWindow = false
            };

            using (var process = Process.Start(psi))
            {
                //string output = process.StandardOutput.ReadToEnd();
                //string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                //if (process.ExitCode != 0)
                //{
                //    throw new Exception($"PowerShell script failed with exit code {process.ExitCode}. Error: {error}");
                //}

                //return output;
                return "";
            }
        }

        public static string RunKillEmulatorPowershellScript(string scriptPath)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"PowerShell script failed with exit code {process.ExitCode}. Error: {error}");
                }

                return output;
            }
        }
    }
}
