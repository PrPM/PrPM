using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using PrPM.Utilities;

namespace PrPM.Tasks
{
    class PackageTask
    {
        private static HttpClient http = new HttpClient();

        private static string npmResponse;

        public static void Run(string pkgName)
        {
            MakeRequest(pkgName).Wait();
            ConsoleUtils.ClearCurrent();
            JObject package = JObject.Parse(npmResponse);
            if ((string)package["error"] == "Not found")
            {
                ConsoleUtils.ErrorAndExit("Package not found.");
            }
            string latestVersion = package["dist-tags"]["latest"].ToString();
            var currentVersion = package["versions"][latestVersion];
            Console.WriteLine($"{package["name"]}@{latestVersion}");
            Console.WriteLine($" => {currentVersion["description"]}");
            // Separator line, same width as description
            Console.WriteLine(new string('-', " => ".Length + currentVersion["description"].ToString().Length));
            if (currentVersion["keywords"] != null) // If keywords exist
            {
                Console.WriteLine($"Keywords:");
                foreach (string keyword in currentVersion["keywords"].ToObject<string[]>())
                {
                    Console.WriteLine($" => {keyword}");
                }
            }
            Console.WriteLine($"{GetAuthorInformation(currentVersion)}");
            Console.WriteLine($"License: {currentVersion["license"]}");
            Console.WriteLine($"Depends on: {GetFormatDependencies(currentVersion)}");
            Console.WriteLine($"View on NPM: https://npmjs.org/packages/{pkgName}");
        }

        private static string GetAuthorInformation(JToken currentVersion)
        {
            return $"Author: {currentVersion["author"]["name"]}\n => E-Mail: {((string)currentVersion["author"]["email"] == null ? "<none>" : currentVersion["author"]["email"])}\n => URL: {((string)currentVersion["author"]["url"] == null ? "<none>" : currentVersion["author"]["url"])}";
        }

        private static string GetFormatDependencies(JToken currentVersion)
        {
            string outputThis = "";
            JObject deps = (JObject)currentVersion["dependencies"];
            string[] dependencyList = deps.Properties().Select(p => p.Name).ToArray();
            foreach (string dep in dependencyList)
            {
                outputThis += $"\n => {dep}@{deps[dep]}";
            }
            if (outputThis == "")
            {
                outputThis += $"\n => Nothing";
            }
            return outputThis;
        }

        private static async Task<string> MakeRequest(string to)
        {
            HttpResponseMessage res = await http.GetAsync($"https://registry.npmjs.org/{to}");
            npmResponse = await res.Content.ReadAsStringAsync();
            return npmResponse;
        }
    }
}