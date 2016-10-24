using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessArgs(args);
            
            PrintHellowWorld();
            //ConsoleHelper.PrintToConsole("Hi There!");
            ConsoleHelper.PrintToConsole("What is your name?");
            var name = ConsoleHelper.ReadFromConsole();
            ConsoleHelper.PrintToConsole("Hello " + name + "!");

            //HaveConversationWithUser();

            //PersonDefinition();

            Instructor instA = new Instructor("English", "Dr. Evil", 50)
            {
                Department = "Evilology"
            };

            instA.Speak();
            instA.Walk();
            instA.InstructorInfo();


            Console.ReadKey();

 
        }

        private static void PersonDefinition()
        {
            Person personA = new Person("English", "Kyle", 23);
            ConsoleHelper.PrintToConsole($"Hello {personA.Name}!");

            personA.Speak();
            ConsoleHelper.PrintToConsole("What is your name?");
            string nameB = ConsoleHelper.ReadFromConsole();
            ConsoleHelper.PrintToConsole("What is your age in whole years?");
            string ageB = ConsoleHelper.ReadFromConsole();
            int intAgeB = 0;
            if (!Int32.TryParse(ageB, out intAgeB))
            {

                ConsoleHelper.PrintToConsole("Incorrect format for age, please use an itneger next time. You're now 5");
                intAgeB = 5;
            }
            ConsoleHelper.PrintToConsole("What language do you speak?");
            string langB = ConsoleHelper.ReadFromConsole();


            Person personB = new Person(langB, nameB, intAgeB);
            personB.Speak();
        }

        static void PrintHellowWorld()
        {
            Console.WriteLine("Hello World!");
        }

        private static void HaveConversationWithUser()
        {
            ConsoleHelper.PrintToConsole("Hello there!");
            string input = ConsoleHelper.ReadFromConsole();

            if (input.Equals("hello"))
            {
                ConsoleHelper.PrintToConsole("Have a nice day!");
            }
            else if (input == "Kyle")
            {
                ConsoleHelper.PrintToConsole($"Nice to meet you, {input}");
            }
            else if (input == "")
            {
                ConsoleHelper.PrintToConsole("Hello, can you hear me?!?");
            }
            else
            {
                switch(input.Substring(0, 1).ToLower())
                {
                    case "a":
                        ConsoleHelper.PrintToConsole("A");
                    break;
                    case "b":
                        ConsoleHelper.PrintToConsole("B");
                    break;
                     case "c":
                     case "d":
                        ConsoleHelper.PrintToConsole("C or D");
                    break;
                    default:
                        ConsoleHelper.PrintToConsole($"Some other letter : {input.Substring(0, 1)}");
                    break;
                }
            }
        }

        private static void ProcessArgs(string[] args)
        {
            List<string> argList = new List<string>();

            if (args.Length == 0)
            {
                ConsoleHelper.PrintToConsole("No arguments!");
                return;
            }

            foreach(string arg in args)
            {
                ConsoleHelper.PrintToConsole($"Foreach Arguments : {arg}");
            }

            for (int index = 0; index < args.Length; index++)
            {
                ConsoleHelper.PrintToConsole($"For Arguments : {args[index]}");
            }

            int windex = 0;
            while (windex < args.Length)
            {
                ConsoleHelper.PrintToConsole($"While Arguments : {args[windex]}");
                windex++;
            }


        }
    }
}
