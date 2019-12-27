using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using PrPM.Utilities;

namespace PrPM.Tasks
{
    class InitTask
    {
        public static void Run()
        {
            Console.Write($"Name ({GenerateProjectName()})> ");
            string name = Console.ReadLine();
            name = (name == "" ? GenerateProjectName() : name);
            Console.Write("Version (0.0.1)> ");
            string ver = Console.ReadLine();
            ver = (ver == "" ? "0.0.1" : ver);
            Console.Write("Description> ");
            string desc = Console.ReadLine();
            Console.Write("Entry Point (app.js)> ");
            string entry = Console.ReadLine();
            entry = (entry == "" ? "app.js" : entry);
            Console.Write("Repo> ");
            string repo = Console.ReadLine();
            Console.Write("Author> ");
            string author = Console.ReadLine();
            Console.Write("License (BSL-1.0)> ");
            string license = Console.ReadLine();
            license = (license == "" ? "BSL-1.0" : license);
            Console.Write("Prevent publish to NPM (any value: yes, no value: no)> ");
            string privateStorage = Console.ReadLine(); // We get the value as a string to parse it later
            bool private_ = (privateStorage == "" ? false : true); // "private" is a C# keyword
            JObject o = JObject.FromObject(new
            {
                name = name,
                version = ver,
                description = desc,
                main = entry,
                repository = repo,
                author = author,
                license = license,
                // from MSFT's docs: "Keywords cannot be used as identifiers in your program unless they include @ as a prefix"
                // the @ character is not visible in the output
                @private = private_
            });
            string json = o.ToString();
            Finalize(json);
        }

        private static void Finalize(string json)
        {
            Console.WriteLine(JsonUtils.FormatJson(json));
            Console.Write("Write to package.json? (y/n)> ");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                File.WriteAllText("package.json", JsonUtils.FormatJson(json));
                Console.WriteLine("Written to package.json.");
            }
            else if (answer == "n")
            {
                Console.WriteLine("Not writing.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Not y or n - please try again.");
            }
        }

        private static string GenerateProjectName()
        {
            return Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar).Last().ToLower();
        }
    }
}