using Contract.App_Code;
using Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Contract.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void SignIn(String UserName, String PassWord)
        {
            using (ContractTransferContext db = new ContractTransferContext())
            {
                string passWord = Cryptography.Md5Hash(PassWord);
                var user = db.Users.SingleOrDefault(m => m.UserName == UserName && m.PassWord == passWord);
                if (user != null)
                {
                    Response.Cookies.Add(new HttpCookie("Name", HttpUtility.UrlEncode(db.Employees.Find(user.ID).RealName)));
                    FormsAuthentication.RedirectFromLoginPage(user.ID.ToString(), false);
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }

        public void SignOut()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}