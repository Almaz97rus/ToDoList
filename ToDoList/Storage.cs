using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ToDoList.Items;
using System.Xml.Linq;

namespace ToDoList
{
    [Serializable]
    public class Storage
    {
        XmlSerializer formatter = new XmlSerializer(typeof(List<Tasks>));
     
        public Storage()
        {
            if (!File.Exists("DataBase.xml"))
            {
                string writePath = @"./DataBase.xml";
                string text = "<?xml version=\"1.0\"?>\n<ArrayOfTasks xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance \"> \n</ArrayOfTasks>";
           
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
        }

        public List<Tasks> SetFileXML(List<Tasks> task)
        {
            using (FileStream fs = new FileStream("DataBase.xml", FileMode.Create))
            {
                formatter.Serialize(fs, task);
            }

            return task;
        }

        public List<Tasks> GetFileXML(List<Tasks> task)
        {
            using (FileStream fs = new FileStream("DataBase.xml", FileMode.Open))
            {
                return task = (List<Tasks>)formatter.Deserialize(fs);
            }
        }
    }
}
