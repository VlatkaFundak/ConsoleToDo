using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// Input - output service.
    /// </summary>
    static class IOService
    {
        /// <summary>
        /// Shows text in the console and adds vertical spaces.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="numberOfSpaces">Number of vertical spaces.</param>
        static public void Print(string message, int numberOfSpaces)
        {
            Program.NumberOfSpaces(numberOfSpaces);
            Console.WriteLine(message);
        }

        /// <summary>
        /// Shows text in the console and adds 0 vertical spaces.
        /// </summary>
        /// <param name="message">Message.</param>
        static public void Print(string message)
        {
            Print(message, 0);
        }
    }
}
