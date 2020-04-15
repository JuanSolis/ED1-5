using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jira_2._0.Models;
using jira_2._0.Utils;

namespace jira_2._0.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        // POST: SignIn/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                string username = collection["UserName"];
                string password = collection["Password"];
                userModel currentUser = new userModel();

                if (currentUser.SignInUser(username,password) == null)
                {
                    Session["SignInMessage"] = "This username doesn't exist, please Sign Up";
                    return RedirectToAction("Index");

                }
                else
                {
                    if(currentUser.SignInUser(username, password).password != password)
                    {
                        Session["SignInMessage"] = "Wrong password, try again";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Session["SignInMessage"] = null;
                        Session["user"] = currentUser.SignInUser(username, password);
                        Storage.Instance.currentUser = (userModel)Session["user"];
                        return RedirectToAction("Index", "Home");
                    }
                }
               
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.Remove("user");
            Storage.Instance.currentUser = null;
            return View("Index");
        }


    }
}
