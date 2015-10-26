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
        /// Shows certain screen.
        /// </summary>
        /// <param name="screen">Certain screen.</param>
        static public void ShowScreen(Screen screen)
        {
            switch (screen)
            {
                case Screen.StartUp:
                    Console.Clear();
                    ShowTitle("Super ToDo Aplication");
                    PrintStartupMessage();
                    break;
            }
        }

        /// <summary>
        /// Creates a startup message.
        /// </summary>
        static private void PrintStartupMessage()
        {
            string message = "Welcome and thank you for using our super cool application for managing todo lists. We really hope you will like it. Please log in or register using your email adress.";
            IOService.Print(message, 2);
            message = "If you have an  account please enter command [Login] and press Enter.\nYou can create an account by entering keyword[Register] and press Enter.";
            IOService.Print(message,1);
        }

        /// <summary>
        /// Creates stars for title.
        /// </summary>
        static private void Stars()
        {
            string stars = new String('*', Console.WindowWidth);
            Console.Write(stars);
        }

        /// <summary>
        /// Creates title.
        /// </summary>
        /// <param name="title">Title.</param>
        static private void ShowTitle(string title)
        {
            Stars();
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
            Stars();
            IOService.Print("", 3);
        }
    }
}
