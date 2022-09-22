using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly Freshers_Training2022Entities dbContext = new Freshers_Training2022Entities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Form_Users user)
        {
            if (ModelState.IsValid)
            {
                bool isValidUser = dbContext.Form_Users.Any(x => x.Username.ToLower() == user.Username.ToLower() && x.Password == user.Password);
                if (isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Employee");
                }
            }
            ModelState.AddModelError(" ", "INVALID USERNAME OR PASSWORD");
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Form_Users registerUser)
        {
            if (ModelState.IsValid)
            {
                dbContext.Form_Users.Add(registerUser);
                dbContext.SaveChanges();
                return RedirectToAction("Login");
            }            
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        } 
    }
}