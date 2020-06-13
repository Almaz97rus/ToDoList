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
   
        public List<string> ReadTextForDb(List<string> sst)
        {         
            fileIn = new StreamReader(path, Encoding.GetEncoding(1251));
            string str;
          
            while ((str = fileIn.ReadLine()) != null) //пока поток не пуст
            {
                sst.Add(str);            
            }

            fileIn.Close();
            return sst;       
        }

        public void AddTextForDb(string st)
        {         
            fileOut = new StreamWriter(path, true, Encoding.Default);
            fileOut.WriteLine(st);
            fileOut.Close();
        }    
    }
}
