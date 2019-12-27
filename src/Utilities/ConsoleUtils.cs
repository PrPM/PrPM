using System;

namespace PrPM.Utilities
{
    class ConsoleUtils
    {
        public static void ClearCurrent(bool existing = true)
        {
            if (existing)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
            int currentLineCur = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCur);
        }

        public static void ErrorAndExit(string error)
        {
            Console.WriteLine(error);
            Environment.Exit(1);
        }
    }
}