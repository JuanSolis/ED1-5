using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using jira_2._0.Models;

namespace jira_2._0.Utils
{
    public class I_O_Manager
    {
        public string fileName { get; set; }
        public string path { get; set; }

        public I_O_Manager(string filename, string path)
        {
            this.fileName = filename;
            this.path = path;
        }

        public void createUserFile()
        {
            if (!File.Exists(this.path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(this.path))
                {
                }
            }
        }

        public void writeInFile(Task currentTask)
        {

                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(this.path))
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},", currentTask.taskTitle,currentTask.proyectName,currentTask.priority,currentTask.taskDescripction,currentTask.date);
                }
            

            // Open the file to read from.
            //using (StreamWriter sr = file.opentext(path))
            //{
            //    string s = "";
            //    while ((s = sr.readline()) != null)
            //    {
            //        console.writeline(s);
            //    }
            //}
        }

    }
}