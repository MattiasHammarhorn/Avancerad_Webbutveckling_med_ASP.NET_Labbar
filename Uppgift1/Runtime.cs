using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1
{
    class Runtime
    {
        public void Start()
        {
            Console.Write("Enter names separated by comma (e.g Maria,Peter,Lisa): ");
            string userInput = Console.ReadLine();
        }

        public string printNamesFromInput(string userInput)
        {

            return ("***" + "SUPER" + userInput.ToUpper() + "***");
        }
    }
}
