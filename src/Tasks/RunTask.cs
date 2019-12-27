using System;
using System.IO;
using PrPM.Utilities;
using Newtonsoft.Json.Linq;

namespace PrPM.Tasks
{
    class RunTask
    {
        public static void Run(string task)
        {
            string runThis = ExtractTask(task);
            Console.WriteLine($" => {runThis}");
            Console.Write(SystemUtils.RunCommand(runThis));
        }

        public static string ExtractTask(string task)
        {
            string command;
            if (File.Exists("package.json"))
            {
                string pkgJson = File.ReadAllText("package.json");
                JObject packageJson = JObject.Parse(pkgJson);
                JObject scripts = packageJson["scripts"].ToObject<JObject>();
                command = (string)scripts[task];
                return command;
            }
            else
            {
                ConsoleUtils.ErrorAndExit("There was no package.json found in this directory.");
                return ""; // never happens; to make the compiler happy
            }
        }
    }
}