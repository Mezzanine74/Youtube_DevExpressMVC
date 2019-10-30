using DevExpress.Web.Mvc;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using YoutubeDevExpressMVC.Web.Models.Db;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public abstract class CRUDController<TEntity> : Controller where TEntity : class, IEntity
    {
        private NorthWindRevEntities _db;
        private DbSet<TEntity> _dbSet;
        private string _className;

        public CRUDController()
        {
            _db = new NorthWindRevEntities();
            _dbSet = _db.Set<TEntity>();
            _className = this.GetType().Name;
            _className = _className.Remove(_className.Length - 10);
        }

        // GET: CRUD
        public ActionResult Index()
        {
            // get class name for PartialView and MainView
            ViewBag.ControllerName = _className;

            var model = _dbSet.AsNoTracking().ToList();

            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            ViewBag.ControllerName = _className;
            return PartialView("_GridViewPartial", _dbSet.AsNoTracking().ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] TEntity item)
        {
            var model = _dbSet;

            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewBag.ControllerName = _className;
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] TEntity item)
        {
            var model = _dbSet;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewBag.ControllerName = _className;
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 Id)
        {
            var model = _dbSet;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            ViewBag.ControllerName = _className;
            return PartialView("_GridViewPartial", model.ToList());
        }

    }
}