using System.Diagnostics;

namespace SharpE2e.Core.Fw
{
    public static class AppLauncher
    {
        public static Process Launch(string exePath)
        {
            var process = new Process();
            process.StartInfo.FileName = exePath;
            process.Start();
            return process;
        }
    }
}
