using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class FileManagerController : Controller
    {
        YoutubeDevExpressMVC.Web.Models.DbGenel.NorthwindRevEntitiesGenel db = new YoutubeDevExpressMVC.Web.Models.DbGenel.NorthwindRevEntitiesGenel();

        // GET: FileManager
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EmployeeFilesUpload(string path, int id)
        {
            db.EmployeeFiles.Add(new Models.DbGenel.EmployeeFile() { EmployeeId = id, FileUrl = path });
            var a = db.SaveChanges();

            if (a == 1)
            {
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EmployeeFilesRemove(string path, int id)
        {
            var model = db.EmployeeFiles.FirstOrDefault(c => c.EmployeeId == id && c.FileUrl == path);
            db.EmployeeFiles.Remove(model);
            var a = db.SaveChanges();

            if (a == 1)
            {
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public ActionResult FileManagerPartial(string rootFolder)
        {
            if (rootFolder != null)
            {
                DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(rootFolder));
                FileManagerControllerFileManagerSettings.RootFolder = rootFolder;
            }

            return PartialView("_FileManagerPartial", FileManagerControllerFileManagerSettings.Model);
        }

        public FileStreamResult FileManagerPartialDownload()
        {
            return FileManagerExtension.DownloadFiles(FileManagerControllerFileManagerSettings.DownloadSettings, FileManagerControllerFileManagerSettings.Model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewEmployeePartial()
        {
            var model = db.Employees;
            ViewBag.Dosyalar = db.EmployeeFiles.ToList();
            return PartialView("_GridViewEmployeePartial", model.ToList());
        }
    }
    public class FileManagerControllerFileManagerSettings
    {
        public static string RootFolder = @"~\Content\Logo\";

        public static string Model { get { return RootFolder; } }
        public static DevExpress.Web.Mvc.FileManagerSettings DownloadSettings
        {
            get
            {
                var settings = new DevExpress.Web.Mvc.FileManagerSettings { Name = "FileManager" };
                settings.SettingsEditing.AllowDownload = true;
                return settings;
            }
        }
    }

}