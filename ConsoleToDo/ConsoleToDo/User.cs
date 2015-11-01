using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// User.
    /// </summary>
    class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ActivationCode { get; set; }
        public List<ToDoItem> TodoList { get; set; }

    }
}
