using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Items;

namespace ToDoList
{
    // После каждого действия сохранять XML файл
    interface IApp
    {
        List<Tasks> GetTasks();

        bool Add(string TaskText);
        bool Delete(int TaskId);
        bool Complete(int TaskId);
        bool Uncomplete(int TaskId);
    }
}
