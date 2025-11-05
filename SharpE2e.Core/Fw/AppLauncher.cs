using System.Diagnostics;
using System.IO;

namespace SharpE2e.Core.Fw
{
    public static class AppLauncher
    {
        public static Process Launch(string exePath)
        {
            if(!File.Exists(exePath))
            {
                throw new FileNotFoundException($"The executable wasn't found: {exePath}");
            }

            var process = new Process();
            process.StartInfo.FileName = exePath;
            process.Start();
            return process;
        }
    }
}
