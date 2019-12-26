using System;

namespace PrPM.Utils
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
    }
}