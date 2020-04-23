using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jira_2._0.Models;
using jira_2._0.Utils;


namespace jira_2._0.Controllers
{
    public class UploadTaskController : Controller
    {
        // GET: UploadTask
        public ActionResult Index()
        {
            return View();
        }

        // POST: UploadTask/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            Random randomNumber = new Random();
            try
            {
                string taskTitle = collection["TaskTitle"];
                string proyectName = collection["ProyectName"];
                string taskDescripction = collection["TaskDescription"];
                string priority = collection["Priority"];
                string dateString = collection["Date"];
                int randomNumberForPriority = 0;
        
                switch (priority)
                {
                    case "Level1_13":
                        {
                            randomNumberForPriority = randomNumber.Next(1, 13);
                        }
                        break;
                    case "Level13_27":
                        {
                            randomNumberForPriority = randomNumber.Next(13, 27);
                        }
                        break;
                    case "Level28_41":
                        {
                            randomNumberForPriority = randomNumber.Next(28, 41);
                        }
                        break;
                    case "Level41_51":
                        {
                            randomNumberForPriority = randomNumber.Next(41, 51);
                        }
                        break;
                    default:
                        randomNumberForPriority = randomNumber.Next(1, 51);
                        break;
                }

                Task taskRegistered = new Task()
                {
                    taskTitle = taskTitle.Replace(',',' '),
                    proyectName = proyectName.Replace(',', ' '),
                    taskDescripction = taskDescripction.Replace(',', ' '),
                    priority = randomNumberForPriority,
                    date = dateString,
                };


                HashCell taskContainer = new HashCell();

                if (taskContainer.insert(taskTitle, taskRegistered))
                {
                    Session.Remove("InsertTask");
                    string fileName = string.Empty;
                    string path = string.Empty;
                    string folder = string.Empty;


                    fileName = Path.GetFileName(Storage.Instance.currentUser.name);

                    if (Storage.Instance.currentUser.role == "Developer")
                    {
                        folder = "Developers";
                    }
                    else
                    {
                        folder = "ProductManagers";
                    }

                    path = Path.Combine(Server.MapPath("~/App_Data/" + folder), fileName + ".csv");
                    I_O_Manager file = new I_O_Manager(fileName, path);
                    file.writeInFile(taskRegistered);


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["InsertTask"] = "Task already exists";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: UploadTask/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UploadTask/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UploadTask/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UploadTask/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
