using System;
using System.Linq;
using System.Web.Mvc;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class GridJsPropertiesController : Controller
    {
        // GET: GridJsProperties
        public ActionResult Index()
        {
            return View();
        }

        YoutubeDevExpressMVC.Web.Models.Db.NorthWindRevEntities db = new YoutubeDevExpressMVC.Web.Models.Db.NorthWindRevEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartialJsProperties()
        {
            var model = db.Products;
            return PartialView("_GridViewPartialJsProperties", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialJsPropertiesAddNew(YoutubeDevExpressMVC.Web.Models.Db.Product item)
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
            return PartialView("_GridViewPartialJsProperties", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialJsPropertiesUpdate(YoutubeDevExpressMVC.Web.Models.Db.Product item)
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

            ViewData["benServerdanGeliyorum"] = $"{item.ProductName} :)";

            return PartialView("_GridViewPartialJsProperties", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialJsPropertiesDelete(System.Int32 Id)
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
            return PartialView("_GridViewPartialJsProperties", model.ToList());
        }
    }
}