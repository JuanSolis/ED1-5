using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using jira_2._0.Models;
using jira_2._0.Utils;

namespace jira_2._0.Models
{
    public class PriorityQueque<Task> where Task : IComparable<Task>
    {
        public List<Task> priorityQueque = new List<Task>();
        public IEnumerable<Task> IenumPriorityQueque;

        public PriorityQueque() {
            IenumPriorityQueque = (IEnumerable<Task>)priorityQueque;
        }

        public void Enqueue(Task taskToScheduler)
        {
            priorityQueque.Add(taskToScheduler);

            int ci = priorityQueque.Count - 1; 
            while (ci > 0)
            {
                int pi = (ci - 1) / 2;

                if (priorityQueque[ci].CompareTo(priorityQueque[pi]) >= 0) {
                    break;
                }
                
                Task tmp = priorityQueque[ci];
                priorityQueque[ci] = priorityQueque[pi];
                priorityQueque[pi] = tmp;
                ci = pi;
            }
        }

        public Task Dequeue()
        {

            int li = priorityQueque.Count - 1; 
            Task taskUnScheduled = priorityQueque[0];   
            priorityQueque[0] = priorityQueque[li];
            Task dato = priorityQueque[li];
            priorityQueque.RemoveAt(li);

            --li; 
            int pi = 0; 
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li) {
                    break;
                }  
                int rc = ci + 1;    
                if (rc <= li && priorityQueque[rc].CompareTo(priorityQueque[ci]) < 0)
                {
                    ci = rc;
                }

                if (priorityQueque[pi].CompareTo(priorityQueque[ci]) <= 0) {
                    break;
                } 
                Task tmp = priorityQueque[pi];
                priorityQueque[pi] = priorityQueque[ci];
                priorityQueque[ci] = tmp; 
                pi = ci;
            }
            return taskUnScheduled;
        }


        public int tasksScheduled()
        {
            return priorityQueque.Count;
        }

        public Task Peek()
        {
            Task taskWithHighPriority = priorityQueque[0];
            return taskWithHighPriority;
        }



    }
}