using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Items
{
    [Serializable]
    /**
     * @TODO: Переименовать Tasks->Task. Так как задача - единственный экземпляр
     */
    public class Tasks
    {
        public int Id { get; set; }
        /**
         * @TODO: Переименовать поле Task в Text или что-то другое, так как сам класс называется Task
         */
        public string Task { get; set; }
        /**
         * Check назвал бы Completed, но это на твое усмотрение
         */
        public bool Check { get; set; }

        public Tasks()
        {
        }

        /**
         * Упростил 
         */
        public Tasks(string task, List<Tasks> Tasks)
        {
            Check = false;
            Task = task;
            Id = 0;

            if (Tasks.Count == 0) return;

            int max = 0;

            foreach (Tasks tsk in Tasks)
            {
                if (tsk.Id > max) max = tsk.Id;
            }

            Id = max + 1;
        }
    }
}
