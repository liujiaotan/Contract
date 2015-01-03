using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Contract.Models;

namespace Contract.Controllers
{
    public class BaseController : Controller
    {
        protected int pageSize
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings.Get("PageSize"));
            }
        }
        private static List<Function> menus;
        protected List<Function> Menus
        {
            get {
                if (menus == null)
                {
                    using (ContractTransferContext db = new ContractTransferContext())
                    {
                        menus = db.Functions.ToList();
                    }
                }
                return menus;
            }
        }
        protected Employee Permissions
        {
            get
            {
                if (Session["employee"] == null)
                {
                    using (ContractTransferContext db = new ContractTransferContext())
                    {
                        if (User.Identity.IsAuthenticated)
                        {
                            var id = int.Parse(this.User.Identity.Name);
                            Session["employee"] = db.Employees.Include("Roles.Modules.Function").Include("Roles.Modules.Operation").FirstOrDefault(m => m.ID == id);
                        }
                    }
                }
                return Session["employee"] as Employee;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (User.Identity.IsAuthenticated && !filterContext.IsChildAction)
            {
                ViewBag.Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                if (!Permissions.Roles.Any(m => m.Modules.Any(n => n.Function.Controller == filterContext.ActionDescriptor.ControllerDescriptor.ControllerName && (filterContext.ActionDescriptor.ActionName == "Index" || n.Operation.Action == filterContext.ActionDescriptor.ActionName))))
                    filterContext.Result = View("Warning");
            }
        }

        public ActionResult Menu(String controller)
        {
            List<Function> functions = null;
            if (User.Identity.IsAuthenticated)
            {

                if (User.Identity.IsAuthenticated)
                {
                    IList<byte> fids = new List<byte>();
                    foreach (var role in Permissions.Roles)
                    {
                        foreach (var module in role.Modules)
                        {
                            if (!fids.Contains(module.FunctionID))
                                fids.Add(module.FunctionID);
                        }
                    }
                    functions = getMenus(fids.ToArray());
                }
                ViewBag.Controller = controller;
                return View(functions);
            }
            else
            {
                return View();
            }           
        }

        private List<Function> getMenus(byte[] id)
        { 
             using (ContractTransferContext db = new ContractTransferContext())
            {
                var functions = Menus.Where(m =>id.Contains(m.ID)).ToList();
                if (functions.Count > 0)
                {
                    functions.AddRange(getMenus(functions.Select(m => m.ParentID).ToArray()));
                }
                return functions;
            }
        }
    }
}