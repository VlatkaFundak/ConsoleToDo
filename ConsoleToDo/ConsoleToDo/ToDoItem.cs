using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// To do item.
    /// </summary>
    class ToDoItem
    {
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool IsCompleted { get; set; }

        /// <summary>
        /// To do item constructor.
        /// </summary>
        /// <param name="description">Description.</param>
        /// <param name="dueDate">Due date.</param>
        /// <param name="isCompleted">Is completed.</param>
        public ToDoItem(string description, string dueDate, bool isCompleted)
        {
            Description = description;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }
    }
}
