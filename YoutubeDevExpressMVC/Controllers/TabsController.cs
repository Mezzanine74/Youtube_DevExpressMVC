using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoutubeDevExpressMVC.Web.Helpers.CustomerTabs;
using YoutubeDevExpressMVC.Web.Models.Db;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class TabsController : Controller
    {
        NorthWindRevEntities db = new Models.Db.NorthWindRevEntities();

        // GET: Tabs
        public ActionResult Index()
        {
            CustomerTabsData customersTab = new CustomerTabsData();

            if (string.IsNullOrEmpty(Request.QueryString["customerId"]?.ToString())
                || string.IsNullOrWhiteSpace(Request.QueryString["customerId"]?.ToString())
                || Request.QueryString["customerId"]?.ToString() == "0")
            {
                foreach (CustomerTabData item in customersTab.Data)
                {
                    return RedirectToAction("Index", new { customerId = item.Customer.Id });
                }
            }

            return View(customersTab);
        }

        public JsonResult GetByCustomer(string companyName)
        {
            var id = db.Customers.FirstOrDefault(c => c.CompanyName == companyName).Id;
            return Json(new { id = id }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int customerId)
        {
            var companyName = db.Customers.FirstOrDefault(c => c.Id == customerId).CompanyName;
            return Json(new { companyName = companyName }, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public ActionResult GridViewOrderPartial(int customerId)
        {
            var model = db.Orders.Where(c => c.CustomerId == customerId);

            return PartialView("_GridViewOrderPartial", model.ToList());
        }
    }
}