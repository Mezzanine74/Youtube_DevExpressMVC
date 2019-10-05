using System;
using System.Linq;
using System.Web.Mvc;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class PopUpController : Controller
    {
        // GET: PopUp
        public ActionResult Index()
        {
            return View();
        }

        YoutubeDevExpressMVC.Web.Models.Db.NorthWindRevEntities db = new YoutubeDevExpressMVC.Web.Models.Db.NorthWindRevEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartialPopup(int SupplierId = 0)
        {
            if (SupplierId == 0)
            {
                var model = db.Products;
                return PartialView("_GridViewPartialPopup", model.ToList());
            }
            else
            {
                var model = db.Products.Where(c => c.SupplierId == SupplierId);
                return PartialView("_GridViewPartialPopup", model.ToList());
            }

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialPopupAddNew(YoutubeDevExpressMVC.Web.Models.Db.Product item)
        {
            var model = db.Products;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartialPopup", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialPopupUpdate(YoutubeDevExpressMVC.Web.Models.Db.Product item, int SupplierId = 0)
        {
            var model = db.Products;

            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartialPopup", SupplierId == 0 ? model.ToList() : model.Where(c => c.SupplierId == SupplierId).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialPopupDelete(System.Int32 Id)
        {
            var model = db.Products;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartialPopup", model.ToList());
        }


        public ActionResult ComboBoxSupplierPartial()
        {
            return PartialView("_ComboBoxSupplierPartial", db.Suppliers.ToList());
        }
    }
}