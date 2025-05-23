using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class Messages
    {
        public void PrintInvalidInputError()
        {
            System.Console.Clear();
            System.Console.WriteLine("Invalid Input, Please try again.");
            Thread.Sleep(2000);
            System.Console.Clear();
        }

        public void PrintInputOutOfRangeError()
        {
            System.Console.Clear();
            System.Console.WriteLine("Input is out of range, Please try again.");
            Thread.Sleep(2000);
            System.Console.Clear();
        }


        public void PrintUserPromptForOption2()
        {
            System.Console.Clear();
            System.Console.WriteLine("Please enter a file path to load the database.");
            Thread.Sleep(2000);
            System.Console.Clear();
        }





    }
}
