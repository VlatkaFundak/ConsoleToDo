using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// Displays full title.
    /// </summary>
    static class UIPresenter
    {
        /// <summary>
        /// Creates title.
        /// </summary>
        /// <param name="title">Title.</param>
        static public void ShowTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Stars();
            Program.NumberOfSpaces(1);
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

        /// <summary>
        /// Creates a startup message.
        /// </summary>
        static public void PrintStartupMessage()
        {
            string message = "Welcome and thank you for using our super cool application for managing todo lists. We really hope you will like it. Please log in or register using your email adress.";
            IOService.Print(message, 3);
            message = "If you have an  account please enter command [Login] and press Enter.";
            IOService.Print(message,2);
            message = "You can create an account by entering keyword [Register] and press Enter.";
            IOService.Print(message);
        }
    }
}
