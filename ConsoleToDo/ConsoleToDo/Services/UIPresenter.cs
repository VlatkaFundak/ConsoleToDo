using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure;

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
                    ShowTitle(Settings.title);
                    PrintStartupMessage();
                    break;

                case Screen.Register:
                    Console.Clear();
                    ShowTitle(Settings.title);
                    IOService.Print(Settings.registrationMessage, 2);
                    break;
            }
        }

        #region Private methods

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

        /// <summary>
        /// Creates a startup message.
        /// </summary>
        static private void PrintStartupMessage()
        {
            IOService.Print(Settings.startUpMessage, 2);
            IOService.Print(Settings.toLogInMessage);
            IOService.Print(Settings.toRegisterMessage,1);
        }

        #endregion
    }
}
