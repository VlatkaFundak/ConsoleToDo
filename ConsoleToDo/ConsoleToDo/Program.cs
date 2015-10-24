using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// Program class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Sets the size of the console.
        /// </summary>
        private static void DimensionsOfTheConsole()
        {
            Console.SetWindowSize(Console.LargestWindowWidth - 40, Console.LargestWindowHeight - 20);
        }
        
        /// <summary>
        /// Number of vertical spaces.
        /// </summary>
        /// <param name="n"></param>
        public static void NumberOfSpaces(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string title = "Super ToDo Aplication";

            DimensionsOfTheConsole();
            UIPresenter.ShowTitle(title);

            UIPresenter.PrintStartupMessage();

            Console.ReadKey();
        }
    }
}
