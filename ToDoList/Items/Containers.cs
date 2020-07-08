using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToDoList.Items
{
    public class Containers
    {
        public List<Tasks> UncheckedContainer { get; set; }
        public List<Tasks> CompleteContainer { get; set; }    
    }
}
