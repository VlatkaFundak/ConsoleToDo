using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Code;
using ConsoleToDo.Code;

namespace ConsoleToDo
{
    /// <summary>
    /// Displays screens.
    /// </summary>
    static class UIPresenter
    {
        #region Public methods

        /// <summary>
        /// Shows certain screen.
        /// </summary>
        /// <param name="screen">Certain screen.</param>
        public static void ShowScreen(Screen screen)
        {
            switch (screen)
            {
                case Screen.StartUp:
                    Console.Clear();
                    ShowTitle(Resources.title);
                    PrintStartupMessage();
                    break;
                case Screen.Register:
                    Console.Clear();
                    ShowTitle(Resources.title);
                    IOService.Print(Resources.registrationMessage, 2);
                    break;
                case Screen.Login:
                    Console.Clear();
                    ShowTitle(Resources.title);
                    IOService.Print(Resources.loginStartupMessage,2);
                    break;
                case Screen.UserProfile:
                    Console.Clear();
                    ShowTitle(Resources.title);
                    User logedInUser = UserRepository.GetLogedInUser();
                    Console.WriteLine("Hi {0}. \t\tYou have {1} todos to complete.\n", logedInUser.Email, UserRepository.NumberOfUncompletedToDos());
                    IOService.Print(Resources.commandsForToDoList,2);
                    ShowToDoList();
                    break;
                case Screen.AddToDoScreen:
                    Console.Clear();
                    ShowTitle(Resources.title);
                    IOService.Print(Resources.addNewItemToList, 2);
                    break;
                case Screen.HistoryScreen:
                    Console.Clear();
                    ShowTitle(Resources.title);
                    IOService.Print(Resources.historyToDo,1);
                    break;
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Creates stars for title.
        /// </summary>
        private static void Stars()
        {
            string stars = new String('*', Console.WindowWidth);
            Console.Write(stars);
        }

        /// <summary>
        /// Creates title.
        /// </summary>
        /// <param name="title">Title.</param>
        private static void ShowTitle(string title)
        {
            Stars();
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
            Stars();
            IOService.Print("", 3);
        }

        /// <summary>
        /// Creates a startup message.
        /// </summary>
        private static void PrintStartupMessage()
        {
            IOService.Print(Resources.startUpMessage, 2);
            IOService.Print(Resources.toLogInMessage);
            IOService.Print(Resources.toRegisterMessage,1);
        }

        /// <summary>
        /// Creates todo list.
        /// </summary>
        private static void ShowToDoList()
        {
            int i = 1;
            User logedInUser = UserRepository.GetLogedInUser();

            foreach (var item in logedInUser.TodoList)
            {
                if (item.IsCompleted == false)
                {
                    Console.WriteLine("{0}.\nDescription: {1}\nDue date: {2}\n", i, item.Description, item.DueDate);
                    i++;
                }
            }
        }

        #endregion
    }
}
