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
        App app = new App();

        public string stringValue;
        public int editId;

   
        public Form2(int id, string text)
        {
            InitializeComponent();

            EditTextBox.Text = text;       
            editId = id;
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            app.Edit(editId,EditTextBox.Text);
            Close();        
        }
    }
}
