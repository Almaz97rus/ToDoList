using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace ToDoList
{
    public class DBuse
    {
       private string path = @"C:\Users\User\source\repos\ToDoList\ToDoList\bin\Debug\DataBase.txt";

        public StreamReader fileIn { get; set; }
        public StreamWriter fileOut { get; set; }
        
        public List<string> ReadTextForDb(List<string> list)
        {         
            fileIn = new StreamReader(path, Encoding.Default);
            string str;
          
            while ((str = fileIn.ReadLine()) != null)       
                list.Add(str);            
            
            fileIn.Close();
            return list;       
        }

        public void DeleteTextForDb(int number, List<string> list)
        {       
            fileOut = new StreamWriter(path, false, Encoding.Default);
            list.RemoveAt(number);
           
            foreach(string str in list)         
                fileOut.WriteLine(str);
                 
            fileOut.Close();
        }

        public void AddTextForDb(string st)
        {         
            fileOut = new StreamWriter(path, true, Encoding.Default);          
            fileOut.WriteLine(st);
            fileOut.Close();
        }  
    }
}
