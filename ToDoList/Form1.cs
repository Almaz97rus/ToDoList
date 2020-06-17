using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        DBuse dBuse = new DBuse();
        List<string> checkedList = new List<string>();
        string str;

        public Form1()
        {
            InitializeComponent();      
            textBox1.Tag = textBox1.Text = "Введите задание...";
         
            dBuse.ReadTextForDb(checkedList);

            foreach (string s in checkedList)           
                checkedListBox1.Items.Add(s);              
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {          
            str = textBox1.Text.ToString();
            checkedListBox1.Items.Add(str);
            dBuse.AddTextForDb(str);
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.Items.RemoveAt(index);
                dBuse.DeleteTextForDb(index, checkedList);       
            }       
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }   
    }
}
