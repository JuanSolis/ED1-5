using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jira_2._0.Models
{
    public class Task
    {
        public string taskTitle { get; set; }
        public string proyectName { get; set; }
        public string taskDescripction { get; set; }
        public int priority { get; set; }
        public DateTime date { get; set; }
    }
}