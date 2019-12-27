using System;
using PrPM.Utilities;

namespace PrPM
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                ConsoleUtils.ErrorAndExit($"Options: info (Display general PrPM info), package (Query a package)");
            }
            if (args[0] == "info")
            {
                Console.WriteLine($"PrPM v{Configuration.version}, {Configuration.copyright_year}");
            }
            else if (args[0] == "package")
            {
                if (args.Length < 2)
                {
                    ConsoleUtils.ErrorAndExit("A package name is required.");
                }
                Console.WriteLine("Please wait while I query NPM...");
                Tasks.PackageTask.Run(args[1]);
            }
            else if (args[0] == "init")
            {
                Tasks.InitTask.Run();
            }
            else if (args[0] == "run")
            {
                Tasks.RunTask.Run(args[1]);
            }
        }
    }
}
