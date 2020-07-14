using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Items
{
    [Serializable]

    public class Task
    {
        public int Id { get; set; }
        
        public string TextTask { get; set; }
        
        public bool Completed { get; set; }

        public Task()
        {
        }

        public Task(string task, List<Task> Tasks)
        {
            Completed = false;
            TextTask = task;
            Id = 0;

            if (Tasks.Count == 0) return;

            int max = 0;

            foreach (Task tsk in Tasks)
            {
                if (tsk.Id > max) max = tsk.Id;
            }

            Id = max + 1;
        }
    }
}
