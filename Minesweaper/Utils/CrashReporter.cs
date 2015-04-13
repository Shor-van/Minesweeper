using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Utils
{
    public static class CrashReporter
    {
        public static void CreateCrashReport(Exception e, string[] data)
        {
            Console.SetBufferSize(220, 40);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Holy Cr*p on a stick, somethings wrong!");
            Console.WriteLine();
            Console.WriteLine("Exception:" + e.Message);
            Console.WriteLine();
            Console.WriteLine("StackTrace");
            Console.WriteLine("=====================");
            Console.WriteLine(e.StackTrace);
            Console.WriteLine();
            Console.WriteLine("Extra Notes");
            Console.WriteLine("=====================");
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }
            Console.WriteLine();
            Console.WriteLine("*End of report*");
            Console.WriteLine("Press any key to close.");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
