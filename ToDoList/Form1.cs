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

        public Form1()
        {
            InitializeComponent();

            TaskAddBox.Text = "Введите задание...";

            foreach (Tasks s in storage.GetFileXML(containerUncheck))
                CheckedBox.Items.Add(s.Task);
        }

        int i = 0; 
        
        private void Add_Task_Button(object sender, EventArgs e)
        {
            if (TaskAddBox.Text.ToString() == "")
                MessageBox.Show("Вы не ввели задание.");
            else
            {
                str = TaskAddBox.Text.ToString();
                CheckedBox.Items.Add(str);           
   
                Tasks task = new Tasks(i,str,false);               
                containerUncheck.Add(task);
                i++;

                storage.SetFileXML(containerUncheck);                            
            }        
        }

        private void Close_Window_Button(object sender, EventArgs e)
        {
            Close();   
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            foreach (int index in CheckedBox.CheckedIndices)
            {
              
            }       
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TaskAddBox.Clear();
        }   
    }
}
