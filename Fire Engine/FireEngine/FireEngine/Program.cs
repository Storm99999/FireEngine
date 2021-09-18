using FireEngine.GameForm;
using FireEngine.StartingScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEngine
{
    class Program
    {
        // Updates Soon
        static void Main(string[] args)
        {
            Console.Title = "Fire Engine";
            Console.WriteLine((string)$@"
  ______ _              ______             _            
 |  ____(_)            |  ____|           (_)           
 | |__   _ _ __ ___    | |__   _ __   __ _ _ _ __   ___ 
 |  __| | | '__/ _ \   |  __| | '_ \ / _` | | '_ \ / _ \
 | |    | | | |  __/   | |____| | | | (_| | | | | |  __/
 |_|    |_|_|  \___|   |______|_| |_|\__, |_|_| |_|\___|
                                      __/ |             
                                     |___/              ");

            Console.WriteLine("\n [1] Play");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Game game = new Game();
            }
        }
    }
}
