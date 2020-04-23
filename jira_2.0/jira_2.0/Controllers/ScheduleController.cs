using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jira_2._0.Utils;
using jira_2._0.Models;

namespace jira_2._0.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dequeue()
        {
            HashCell taskContainer = new HashCell();
            Task taskToDelete = Storage.Instance.currentUser.scheduledTasks.Peek();
            int i = 0;
            bool found = false;
            int index = 0;
            while (!found)
            {

                index = taskContainer.HashF(taskToDelete.taskTitle, i);

                if (Storage.Instance.hashTable[index].key.Equals(taskToDelete.taskTitle))
                {
                    found = true;
                    Storage.Instance.hashTable[index].key = null;
                    Storage.Instance.hashTable[index].taskDetails = null;
                    Storage.Instance.hashTable[index].state = HashCell.cellState.vacio;
                }
                else
                {
                    found = false;
                }
            }

            Storage.Instance.currentUser.scheduledTasks.Dequeue();

            return View("Index");
        }

    }
}
