using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgfit1.Utility
{
    class Visuals
    {
        // Some sweet visuals for the user
        public static void Welcome()
        {
            Console.Title = "Prime program";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"
        _ _ _ ____ _    ____ ____ _  _ ____ 
        | | | |___ |    |    |  | |\/| |___ 
        |_|_| |___ |___ |___ |__| |  | |___ " + "\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
