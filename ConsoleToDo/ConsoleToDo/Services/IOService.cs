﻿using System;
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
        #region Public methods

        /// <summary>
        /// Shows text in the console and adds vertical spaces.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="numberOfSpaces">Number of vertical spaces.</param>
        public static void Print(string message, int numberOfSpaces)
        {
            Console.WriteLine(message);

            for (int i = 0; i < numberOfSpaces; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Shows text in the console and adds 0 vertical spaces.
        /// </summary>
        /// <param name="message">Message.</param>
        public static void Print(string message)
        {
            Print(message, 0);
        }

        #endregion
    }
}
