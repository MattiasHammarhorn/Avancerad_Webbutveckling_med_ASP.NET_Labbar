using System;

namespace Uppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter names separated by comma (e.g Maria,Peter,Lisa): ");
            string userInput = Console.ReadLine();
            splitAndLoopThroughInput(userInput);
        }

        public static void splitAndLoopThroughInput(string userInput)
        {
            string[] inputToBeParsed = userInput.Split(',');
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string name in inputToBeParsed)
            {
                Console.WriteLine("***" +  "SUPER-" + name.ToUpper() + "***");
            }
            Console.ResetColor();
        }
    }
}
