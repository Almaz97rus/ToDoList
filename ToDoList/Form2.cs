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
    public partial class Form2 : Form
    {
        App app;

        public string stringValue;
        public int editId;
        public bool checkin;

   
        public Form2(int id, string text, App app, bool check)
        {
            InitializeComponent();

            EditTextBox.Text = text;       
            editId = id;
            checkin = check;

            this.app = app;
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            app.Edit(editId,EditTextBox.Text,checkin);
            Close();        
        }
    }
}
