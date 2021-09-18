using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEngine.FireEngine.Logs
{
    public static class Log
    {
        public static void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("INFO");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("] " + message + "\n");
        }
        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("ERROR");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("] " + message + "\n");
        }
    }
}
