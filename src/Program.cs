using System;
using PrPM;

namespace PrPM
{
    class Program
    {
        public static void ErrorAndExit(string error)
        {
            Console.WriteLine(error);
            Environment.Exit(1);
        }

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                ErrorAndExit($"Options: info (Display general PrPM info), package (Query a package)");
            }
            if (args[0] == "info")
            {
                Console.WriteLine($"PrPM v{Configuration.version}, {Configuration.copyright_year}");
            }
            else if (args[0] == "package")
            {
                if (args.Length < 2)
                {
                    ErrorAndExit("A package name is required.");
                }
                Console.WriteLine("Please wait while I query NPM...");
                Tasks.PackageTask.Run(args[1]);
            }
            else if (args[0] == "init")
            {
                Tasks.InitTasks.Run();
            }
        }
    }
}
