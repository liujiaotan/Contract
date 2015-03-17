using Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contract.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public JsonResult Companies(string q)
        {

            List<Company> companies = null;
            using(ContractTransferContext db = new ContractTransferContext())
            {
                companies = db.Companies.Where(m=>m.Name.Contains(q)).ToList();
            }

            return Json(companies.Select(m => new { id = m.ID, name = m.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Company(int? id)
        {

            Company company = null;
            using (ContractTransferContext db = new ContractTransferContext())
            {
                company = db.Companies.Find(id);
            }

            return Json(company, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Employees(int? id)
        {
            List<checkSelect> checkSelects = new List<checkSelect>();
            using (ContractTransferContext db = new ContractTransferContext())
            {
                var toTasks = db.Routes.Where(m=>m.FromTask==id);
                foreach(var task in toTasks)
                {
                    var employees = task.Task1.Role.Employees;
                    foreach(var employee in employees)
                    {
                        checkSelects.Add(new checkSelect{text = employee.RealName+ "（" + task.Task1.Role.Name + "）",value = task.ID.ToString()+","+employee.ID});
                    }
                }
            }
            //var employees = toTasks.Select(m => m.Role.Employees);

            return Json(checkSelects, JsonRequestBehavior.AllowGet);
        }

        private class checkSelect {
            public String text { get; set; }
            public String value { get; set; }
        }
    }
}