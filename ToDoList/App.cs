using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToDoList.Items;

namespace ToDoList
{
    public class App : IApp
    {
        Storage storage = new Storage();
        List<Task> TasksBox = new List<Task>();

        public App()
        {
            foreach (Task task in storage.GetFileXML(TasksBox))
            {
                TasksBox.Add(task);
            }
        }

        public List<Task> GetTasks()
        {
            return TasksBox;
        }

        public Task Add(string TaskText)
        {
            Task task = new Task(TaskText, TasksBox);

            TasksBox.Add(task);

            storage.SetFileXML(TasksBox);

            return task;
        }

        public bool Delete(int TaskId)
        {       
            foreach (Task task in TasksBox)
            {
                if (task.Id == TaskId)
                {
                    TasksBox.Remove(task);
                    storage.SetFileXML(TasksBox);
                    return true;
                }
            }

            return false;
        }

        public bool Complete(int TaskId)
        {        
            foreach (Task task in TasksBox)
            {
                if (task.Id == TaskId)
                {
                    task.Completed = true;
                    storage.SetFileXML(TasksBox);

                    return true;
                }
            }

            return false;
            
        }

        public bool Uncomplete(int TaskId)
        {         
            foreach (Task task in TasksBox)
            {
                if (task.Id == TaskId)
                {
                    task.Completed = false;
                    storage.SetFileXML(TasksBox);
                    return true;
                }
            }

            return false;       
        }

        public bool Edit(int TaskId, string TaskText, bool Check)
        {
            foreach (Task task in TasksBox)
            {
                if (task.Id == TaskId)
                {
                    task.TextTask = TaskText;
                    break;
                }
            }
            storage.SetFileXML(TasksBox);
            return true;

        }
    }
}
