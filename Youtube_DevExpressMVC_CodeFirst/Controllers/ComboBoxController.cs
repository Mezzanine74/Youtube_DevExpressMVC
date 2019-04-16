using System.Linq;
using System.Web.Mvc;
using YoutubeDevExpressMVC.Web.Models.Db;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class ComboBoxController : Controller
    {
        NorthWindRevEntities db = new NorthWindRevEntities();

        // GET: ComboBox
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComboBoxProductPartial()
        {
            return PartialView("_ComboBoxProductPartial", db.Products.ToList());
        }

        public ActionResult ComboBoxCategoryPartial()
        {
            return PartialView("_ComboBoxCategoryPartial", db.Categories.ToList());
        }

        public ActionResult ComboBoxSupplierPartial()
        {
            return PartialView("_ComboBoxSupplierPartial", db.Suppliers.ToList());
        }

    }
}