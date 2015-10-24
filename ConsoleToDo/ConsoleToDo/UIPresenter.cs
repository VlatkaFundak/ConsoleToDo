using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    static class UIPresenter
    {
        /// <summary>
        /// Creates title.
        /// </summary>
        /// <param name="title"></param>
        static public void ShowTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Stars();
            Console.WriteLine();
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
            Stars();
        }
        
        /// <summary>
        /// Creates stars for title.
        /// </summary>
        static private void Stars()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
        }
    }
}
