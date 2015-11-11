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
        #region Public methods

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
                case Screen.Login:
                    Console.Clear();
                    ShowTitle(Settings.title);
                    IOService.Print(Settings.loginStartupMessage,2);
                    break;
                case Screen.UserProfile:
                    Console.Clear();
                    ShowTitle(Settings.title);
                    Console.WriteLine("Hi {0}. \t\tYou have {1} todos to complete.\n", UsersDatabase.LogedInUser.Email, UsersDatabase.NumberOfUncompletedToDos());
                    IOService.Print(Settings.commandsForToDoList,2);
                    ShowToDoList();
                    break;
                case Screen.AddToDoScreen:
                    Console.Clear();
                    ShowTitle(Settings.title);
                    IOService.Print(Settings.addNewItemToList, 2);
                    break;
                case Screen.HistoryScreen:
                    Console.Clear();
                    ShowTitle(Settings.title);
                    IOService.Print(Settings.historyToDo,1);
                    break;
            }
        }

        #endregion

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

        /// <summary>
        /// Creates todo list.
        /// </summary>
        static private void ShowToDoList()
        {
            int i = 1;
            foreach (var item in UsersDatabase.LogedInUser.TodoList)
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
