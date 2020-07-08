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
        App app = new App();

        //Storage storage = new Storage();
        //List<Tasks> TasksBox = new List<Tasks>();

        public Form1()
        {           
            InitializeComponent();

            DataTasksContainer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTasksContainer.AllowUserToAddRows = false;

            TaskAddBox.Text = "Введите задание...";
              
            foreach (Tasks task in app.GetTasks())
            {
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
            
            //app.Add();

            string textInput = TaskAddBox.Text.ToString().Trim();

         

            if (textInput == "")
            {
                MessageBox.Show("Вы не ввели задание.");
                
                return;
            }
       
            Tasks task = app.Add(textInput);       
            DataTasksContainer.Rows.Add(task.Id, task.Task, task.Check);
        }

        private void Close_Window_Button(object sender, EventArgs e)
        {              
            Close();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TaskAddBox.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {               
            foreach (DataGridViewRow row in DataTasksContainer.SelectedRows)
            {
                DataTasksContainer.Rows.Remove(row);
                app.Delete(Convert.ToInt32(row.Cells[0].Value));               
            }
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            // App.Complete();
            foreach (DataGridViewRow row in DataTasksContainer.SelectedRows)
            {

                row.Cells[2].Value = true;
                app.Complete(Convert.ToInt32(row.Cells[0].Value));              
            }
        }

        private void Not_Completed_Click(object sender, EventArgs e)
        {
            // App.Uncomplete();
            foreach (DataGridViewRow row in DataTasksContainer.SelectedRows)
            {
                row.Cells[2].Value = false;
                app.Uncomplete(Convert.ToInt32(row.Cells[0].Value));
               
            }
        }
    }
}