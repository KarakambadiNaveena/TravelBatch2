using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace travelapp1.Controllers
{
    public class UserController : Controller
    {
        Operations cd = new Operations();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(FormCollection c)
        {
            string s = c["Email"].ToString();
            string k = c["Password"].ToString();
            bool k1 = false;
            foreach (var item in cd.GetUser())
            {
                if (item.Email == s && item.Password == k)
                {
                    TempData["User"] = item;
                    Session["u1"] = item;
                    k1 = true;
                }
            }
            if (k1)
            {
                return RedirectToAction("Index");
               
            }
            else
            {
                ViewBag.Message = "Invalid Credentials..Try Again";
                return View();
            }


        }
    }
}