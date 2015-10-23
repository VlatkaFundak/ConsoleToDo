using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    class Program
    {
        public static void DimensionsOfTheConsole()
        {
            Console.SetWindowSize(200,40);
        }

        static void Main(string[] args)
        {
            string title = "Super ToDo Aplication";

            DimensionsOfTheConsole();
            UIPresenter.ShowTitle(title);

            Console.ReadKey();
        }
    }
}
