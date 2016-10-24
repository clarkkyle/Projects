using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsole
{
    public static class ConsoleHelper
    {
        public static void PrintToConsole(string valueToPrint)
        {
            Console.WriteLine(valueToPrint);
        }
        public static string ReadFromConsole()
        {
            return Console.ReadLine();
        }

        

    }
}
