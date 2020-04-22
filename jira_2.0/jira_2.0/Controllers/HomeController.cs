using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jira_2._0.Models;
using jira_2._0.Utils;

namespace jira_2._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Storage.Instance.hashTable.Count == 0)
            {
                Storage.Instance.hashTableInitialization.insertEmptyCells();
            }

                return View();
                        
        }

    }
}