using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToDoList.Items;

namespace ToDoList
{
    // После каждого действия сохранять XML файл
    interface IApp
    {
        List<Tasks> GetTasks();

        Tasks Add(string TaskText);
        Tasks Edit(string TaskText, bool Check);
        bool Delete(int TaskId);
        /**
         * Частный случай функции Edit()
         */
        bool Complete(int TaskId);
        /**
         * Частный случай функции Edit()
         */
        bool Uncomplete(int TaskId);
    }
}
