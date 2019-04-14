using System;
using System.Linq;
using System.Web.Mvc;
using YoutubeDevExpressMVC.Web.Models.Db;


namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class GridViewController : Controller
    {
        // GET: GridView
        public ActionResult Index()
        {
            return View();
        }

        NorthwindRevEntities db = new NorthwindRevEntities();

        [ValidateInput(false)]
        public ActionResult GridViewDemoPartial()
        {
            var model = db.Categories;
            ViewBag.ProductListesi = db.Products.ToList();
            return PartialView("_GridViewDemoPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewDemoPartialAddNew(Category item)
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
        public ActionResult GridViewDemoPartialUpdate(Category item)
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

        public ActionResult Products()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewProductsPartial()
        {
            ViewBag.Supplier = db.Suppliers.Select(c => new { c.Id, c.CompanyName }).ToList();
            ViewBag.Category = db.Categories.Select(c => new { c.Id, c.CategoryName }).ToList();

            var model = db.Products;
            return PartialView("_GridViewProductsPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewProductsPartialAddNew(Product item)
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
            return PartialView("_GridViewProductsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewProductsPartialUpdate(Product item)
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
            return PartialView("_GridViewProductsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewProductsPartialDelete(System.Int32 Id)
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
            return PartialView("_GridViewProductsPartial", model.ToList());
        }

        public ActionResult TumKolonlar()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewTumKolonlarPartial()
        {
            var model = db.Products;
            return PartialView("_GridViewTumKolonlarPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewTumKolonlarPartialAddNew(YoutubeDevExpressMVC.Web.Models.Db.Product item)
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
            return PartialView("_GridViewTumKolonlarPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewTumKolonlarPartialUpdate(YoutubeDevExpressMVC.Web.Models.Db.Product item)
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
            return PartialView("_GridViewTumKolonlarPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewTumKolonlarPartialDelete(System.Int32 Id)
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
            return PartialView("_GridViewTumKolonlarPartial", model.ToList());
        }
    }
}