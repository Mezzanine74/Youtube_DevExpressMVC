using System;
using System.Linq;
using System.Web.Mvc;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class GridViewController : Controller
    {
        // GET: GridView
        public ActionResult Index()
        {
            return View();
        }

        YoutubeDevExpressMVC.Web.Models.Db.NorthwindRevEntities db = new YoutubeDevExpressMVC.Web.Models.Db.NorthwindRevEntities();

        [ValidateInput(false)]
        public ActionResult GridViewDemoPartial()
        {
            var model = db.Categories;
            ViewBag.ProductListesi = db.Products.ToList();
            return PartialView("_GridViewDemoPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewDemoPartialAddNew(YoutubeDevExpressMVC.Web.Models.Db.Category item)
        {
            var model = db.Categories;
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
            return PartialView("_GridViewDemoPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewDemoPartialUpdate(YoutubeDevExpressMVC.Web.Models.Db.Category item)
        {
            var model = db.Categories;
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
            return PartialView("_GridViewDemoPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewDemoPartialDelete(System.Int32 Id)
        {
            var model = db.Categories;
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
            return PartialView("_GridViewDemoPartial", model.ToList());
        }
    }
}