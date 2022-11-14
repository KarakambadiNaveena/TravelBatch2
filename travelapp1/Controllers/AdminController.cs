using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace travelapp1.Controllers
{
    public class AdminController : Controller
    {
        Operations cd = new Operations();
        // GET: Admin
        public ActionResult Index()
        {
           
                List<User> l = new List<User>();
                l = cd.GetUser();
                return View(l);
            }
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection c)
        {
            string s = c["AdminEmail"].ToString();
            string k = c["AdminPassword"].ToString();
            bool k1 = false;
            foreach (var item in cd.GetAdmin())
            {
                if (item.AdminEmail == s && item.AdminPassword == k)
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