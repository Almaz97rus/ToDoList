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
   
        public Form1()
        {
            InitializeComponent();

            ToolStripMenuItem editCompleteStatusMenuItem = new ToolStripMenuItem("Изменить статус: Выполнено");
            ToolStripMenuItem editNonCompleteStatusMenuItem = new ToolStripMenuItem("Изменить статус: Не Выполнено");
            ToolStripMenuItem editTextMenuItem = new ToolStripMenuItem("Изменить текст");
            ToolStripMenuItem deleteTextMenuItem = new ToolStripMenuItem("Удалить");

            contextMenuStrip1.Items.AddRange(new[] { editCompleteStatusMenuItem, editNonCompleteStatusMenuItem, editTextMenuItem, deleteTextMenuItem });

            DataTasksContainer.ContextMenuStrip = contextMenuStrip1;

            editCompleteStatusMenuItem.Click += CompleteButton_Click;
            editNonCompleteStatusMenuItem.Click += Not_Completed_Click;
            editTextMenuItem.Click += Edit_Text_Click; ;
            deleteTextMenuItem.Click += DeleteButton_Click;

            DataTasksContainer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTasksContainer.AllowUserToAddRows = false;

            TaskAddBox.Text = "Введите задание...";
         
            Fill();
        }

        public void Fill()
        {
            foreach (Items.Task task in app.GetTasks())
            {
                int rowIndex = DataTasksContainer.Rows.Add(task.Id,task.TextTask,task.Completed);

                ChangeColor(rowIndex, task.Completed);
            }
        }
      
        private void ChangeColor(int rowIndex, bool complete)
        {         
                    if (complete == true)
                    {
                        DataTasksContainer.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                    }
                    else
                    {
                        DataTasksContainer.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }                                          
        }

        private void Add_Task_Button(object sender, EventArgs e)
        {
            string textInput = TaskAddBox.Text.ToString().Trim();

            if (textInput == "")
            {
                MessageBox.Show("Вы не ввели задание.");

                return;
            }

            Items.Task task = app.Add(textInput);

            int rowIndex = DataTasksContainer.Rows.Add(task.Id,task.TextTask,task.Completed);

            ChangeColor(rowIndex, task.Completed);
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
                int taskId = Convert.ToInt32(row.Cells[0].Value);

                DataTasksContainer.Rows.Remove(row);
             
                app.Delete(taskId);
            }
        }
    
        private void CompleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataTasksContainer.SelectedRows)
            {              
                ChangeColor(row.Index,true);

                app.Complete(Convert.ToInt32(row.Cells[0].Value));
                        
            }
        }
        
        private void Not_Completed_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataTasksContainer.SelectedRows)
            {             
                ChangeColor(row.Index,false);

                app.Uncomplete(Convert.ToInt32(row.Cells[0].Value));
             
            }
        }

        private void Edit_Text_Click(object sender, EventArgs e)
        {        
            foreach (DataGridViewRow row in DataTasksContainer.SelectedRows)
            {
                Form2 newForm = new Form2(Convert.ToInt32(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value));
                newForm.Show();

                DataTasksContainer.Rows.Clear();

                Fill();
            }
        }
    }
}