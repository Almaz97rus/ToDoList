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
            int max = 0; ;

            if (Tasks.Count == 0)
            {
                Id = 0;
            }
            else
            {
                foreach (Tasks tsk in Tasks)
                {
                    if (tsk.Id > max)
                        max = tsk.Id;
                
                }

                Id = max+1;
            }
                
            Check = false;
            Task = task;
        }  
    }
}
