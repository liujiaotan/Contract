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
    }
}