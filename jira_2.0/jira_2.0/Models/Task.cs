using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jira_2._0.Models
{
    public class Task : IComparable<Task>
    {
        public string taskTitle { get; set; }
        public string proyectName { get; set; }
        public string taskDescripction { get; set; }
        public int priority { get; set; }
        public string date { get; set; }


        public int CompareTo(Task other)
        {
            if (this.priority < other.priority)
            {
                return -1;
            }
            else if (this.priority > other.priority)
            {
                return 1;
            }
            else {
                return 0;
            }
         
        }


    }

}