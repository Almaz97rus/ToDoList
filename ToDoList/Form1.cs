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

        public Form1()
        {
            InitializeComponent();      
            textBox1.Tag = textBox1.Text = "Введите ФИО";

            List<string> st = new List<string>();

            dBuse.ReadTextForDb(st);

            foreach (string s in st)
            {
                checkedListBox1.Items.Add(s);
            }

           // checkedListBox1.ForeColor = System.Drawing.Color.Red;       
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            string st;
            st = textBox1.Text.ToString();
            checkedListBox1.Items.Add(st);
            dBuse.AddTextForDb(st);
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.ClearSelected();          
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
