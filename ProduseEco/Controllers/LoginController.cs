using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProduseEco.Models;
using ProduseEco.ViewModel;

namespace ProduseEco.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login login)
        
        {
            if (ModelState.IsValid)
            {
                using (masterEntities2 lg = new masterEntities2())
                {
                    var v = lg.Clients.Where(a => a.Username.Equals(login.Username) && a.Password.Equals(login.Password)).FirstOrDefault();

                    if (v != null)
                    {
                        Session["LogedUserID"] = v.Id.ToString();
                        Session["LogedUserFullname"] = v.Username.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(login);
        }
        public ActionResult AfterLogin() {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        private Client ClientViewModelToClient(ClientViewModel U)
        {
            return new Client()
            {
                
                Password = U.Password,
                
                Username = U.Username,
               
            };
        }
    }
}