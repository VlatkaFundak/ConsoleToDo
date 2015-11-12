using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo.Code
{
    /// <summary>
    /// To do item model class.
    /// </summary>
    public class ToDoItem
    {
        #region Properties

        /// <summary>
        /// Description of ToDo task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Due date of ToDo task.
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// True if task is completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// To do item constructor.
        /// </summary>
        /// <param name="description">Description.</param>
        /// <param name="dueDate">Due date.</param>
        /// <param name="isCompleted">Is completed.</param>
        public ToDoItem(string description, string dueDate, bool isCompleted)
        {
            this.Description = description;
            this.DueDate = dueDate;
            this.IsCompleted = isCompleted;
        }

        #endregion
    }
}
