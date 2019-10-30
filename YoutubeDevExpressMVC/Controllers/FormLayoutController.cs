using System.Linq;
using System.Web.Mvc;
using YoutubeDevExpressMVC.Web.Models.Db;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class FormLayoutController : Controller
    {
        NorthWindRevEntities db = new NorthWindRevEntities();

        // GET: FormLayout
        public ActionResult Index()
        {
            ViewBag.Supplier = db.Suppliers.Select(c => new { c.Id, c.CompanyName }).ToList();
            ViewBag.Category = db.Categories.Select(c => new { c.Id, c.CategoryName }).ToList();
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Product(Product model)
        {
            var state = ModelState.IsValid;

            return RedirectToAction(nameof(this.Index));
        }
    }
}