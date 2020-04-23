using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using jira_2._0.Models;
using jira_2._0.Utils;

namespace jira_2._0.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        // POST: SignUp/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                string username = collection["UserName"];
                string password = collection["Password"];
                string role = collection["Role"];
                userModel registeredUser = new userModel();
                if (registeredUser.SignUpUser(username, password,role) == null)
                {
                    Session["SignUpMessage"] = "Try again, this username is already taken";
                    return RedirectToAction("Index", "SignUp");
                }
                else
                {
                    string fileName = string.Empty;
                    string path = string.Empty;
                    string folder = string.Empty;

                    Storage.Instance.registeredUsers.Add(registeredUser);
                    Session.Remove("SignUpMessage");

                    fileName = Path.GetFileName(registeredUser.name);

                    if (registeredUser.role == "Developer")
                    {
                        folder = "Developers";
                    }
                    else
                    {
                        folder = "ProductManagers";
                    }

                    path = Path.Combine(Server.MapPath("~/App_Data/"+ folder), fileName + ".csv");
                    I_O_Manager file = new I_O_Manager(fileName, path);
                    file.createUserFile();

                    return RedirectToAction("Index", "SignIn");
                }
                
            }
            catch
            {
                return View();
            }
        }

      
    }
}
