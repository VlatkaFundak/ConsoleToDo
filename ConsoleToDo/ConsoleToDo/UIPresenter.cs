using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    static class UIPresenter
    {
        static public void ShowTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            for (int i = 0; i < 200; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));

            for (int i = 0; i < 200; i++)
            {
                Console.Write("*");
            }
        }
    }
}
