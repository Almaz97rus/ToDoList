using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Items
{
    [Serializable]
    public class Tasks
    {
        public int Id { get; set; }
        public string Task { get; set; }     
        public bool Check { get; set; }

        public Tasks()
        { 
        
        
        }

      
        public Tasks(string task, List<Tasks> Tasks)
        {
            if (Tasks.Count == 0)
            {
                Id = 0;
            }
            else
            {
                Id = Tasks.Count;
            }
                
            Check = false;
            Task = task;
        }

        public Tasks(int id, string task, bool check)
        {
            Id = id;
            Task = task;
            Check = check;
        }
    }
}
