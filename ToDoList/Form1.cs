using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToDoList.Items;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        string str;

        Storage storage = new Storage();
        List<Tasks> containerUncheck = new List<Tasks>();
        int i;

        public Form1()
        {
            InitializeComponent();

            TaskAddBox.Text = "Введите задание...";

            foreach (Tasks s in storage.GetFileXML(containerUncheck))
            {
                containerUncheck.Add(s);

                if (s.Check == false)
                {
                    CheckedBox.Items.Add(s.Task);
                }
                if (s.Check == true)
                {
                    CompleteTaskBox.Items.Add(s.Task);
                }
            }

            i = containerUncheck.Count;
        }


        private void Add_Task_Button(object sender, EventArgs e)
        {
            if (TaskAddBox.Text.ToString() == "")
                MessageBox.Show("Вы не ввели задание.");
            else
            {
                str = TaskAddBox.Text.ToString();
                CheckedBox.Items.Add(str);

                Tasks task = new Tasks(i, str, false);
                containerUncheck.Add(task);
                i++;
            }
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

        private void CheckedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int r = CheckedBox.SelectedIndex;
         
            containerUncheck[r].Check = true;

            CompleteTaskBox.Items.Add(containerUncheck.ElementAt(CheckedBox.SelectedIndex).Task);
            CheckedBox.Items.Remove(containerUncheck.ElementAt(CheckedBox.SelectedIndex).Task);            
        }
    }
}