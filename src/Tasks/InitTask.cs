using System;
using System.Linq;
using System.IO;

namespace PrPM.Tasks
{
    class InitTasks
    {
        public static void Run()
        {
            Console.Write($"Name ({System.IO.Directory.GetCurrentDirectory().Split(System.IO.Path.DirectorySeparatorChar).Last()})> ");
            string name = Console.ReadLine();
            name = (name == "" ? System.IO.Directory.GetCurrentDirectory().Split(System.IO.Path.DirectorySeparatorChar).Last() : name);
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
            string private_ = Console.ReadLine(); // "private" is a C# keyword

        }
    }
}