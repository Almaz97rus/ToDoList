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
        // Нормальное название сделай, нихрена непонятно (например, TextInput)
        string str;

        Storage storage = new Storage();
        // Поменять наименование
        List<Tasks> containerUncheck = new List<Tasks>();

        public Form1()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            TaskAddBox.Text = "Введите задание...";

            // Поменять наименование у переменных "y" и "s"
            int y = 0;
            foreach (Tasks s in storage.GetFileXML(containerUncheck))
            {
                dataGridView1.Rows.Add(s.Id, s.Task, s.Check);
                containerUncheck.Add(s);
                // Не менять ID - на то он и ID
                s.Id = y;
                y++;
            }

            // Красить ячейки в прошлом цикле. dataGridView1.Rows.Add отдает индекс строки, которую нужно покрасить
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((bool)row.Cells[2].Value == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void Add_Task_Button(object sender, EventArgs e)
        {
            // Почитать про функцию Trim()
            if (TaskAddBox.Text.ToString() == "")
            {
                MessageBox.Show("Вы не ввели задание.");
                // Пример раннего выхода из функции
                return;
            }

            // Trim()
            str = TaskAddBox.Text.ToString();

            Tasks task = new Tasks(dataGridView1.Rows.Count + 1, str, false);

            containerUncheck.Add(task);

            dataGridView1.Rows.Add(task.Id, task.Task, task.Check);
        }

        private void Close_Window_Button(object sender, EventArgs e)
        {
            storage.SetFileXML(containerUncheck);
            Close();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TaskAddBox.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
                containerUncheck.RemoveAt(Convert.ToInt32(row.Cells[0].Value));
            }
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                row.Cells[2].Value = true;
                containerUncheck[Convert.ToInt32(row.Cells[0].Value)].Check = true;
            }
        }

        private void Not_Completed_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                row.Cells[2].Value = false;
                containerUncheck[Convert.ToInt32(row.Cells[0].Value)].Check = false;
            }
        }
    }
}