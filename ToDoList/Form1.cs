using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.Items;

namespace ToDoList
{
    public partial class Form1 : Form
    {       
        // App app = new App();
        Storage storage = new Storage();
   
        List<Tasks> TasksBox = new List<Tasks>();
  
        public Form1()
        {           
            InitializeComponent();

            DataTasksContainer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTasksContainer.AllowUserToAddRows = false;

            TaskAddBox.Text = "Введите задание...";

            // Взаимодействие со Storage внутри App
            // storage.GetFileXML(TasksBox) -> App.GetTasks()

            foreach (Tasks task in storage.GetFileXML(TasksBox))
            {
                TasksBox.Add(task);
              
                int rowIndex = DataTasksContainer.Rows.Add(task.Id, task.Task, task.Check);

                if (task.Check == true)
                {                                 
                    DataTasksContainer.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    DataTasksContainer.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
            }
   
        }

        private void Add_Task_Button(object sender, EventArgs e)
        {
            // App.Add();
            string textInput = TaskAddBox.Text.ToString().Trim();

            if (textInput == "")
            {
                MessageBox.Show("Вы не ввели задание.");
                
                return;
            }

            Tasks task = new Tasks(textInput, TasksBox);

            TasksBox.Add(task);

            DataTasksContainer.Rows.Add(task.Id, task.Task, task.Check);
        }

        private void Close_Window_Button(object sender, EventArgs e)
        {
            // Сохранение после каждого действия в App
            storage.SetFileXML(TasksBox);
            Close();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TaskAddBox.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // App.Delete();
            foreach (DataGridViewRow row in DataTasksContainer.SelectedRows)
            {
                DataTasksContainer.Rows.Remove(row);
                TasksBox.RemoveAt(Convert.ToInt32(row.Cells[0].Value));
            }
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            // App.Complete();
            foreach (DataGridViewRow row in DataTasksContainer.SelectedRows)
            {
                row.Cells[2].Value = true;
                TasksBox[Convert.ToInt32(row.Cells[0].Value)].Check = true;
            }
        }

        private void Not_Completed_Click(object sender, EventArgs e)
        {
            // App.Uncomplete();
            foreach (DataGridViewRow row in DataTasksContainer.SelectedRows)
            {
                row.Cells[2].Value = false;
                TasksBox[Convert.ToInt32(row.Cells[0].Value)].Check = false;
            }
        }
    }
}