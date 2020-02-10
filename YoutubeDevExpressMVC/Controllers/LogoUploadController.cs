using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class LogoUploadController : Controller
    {
        // GET: LogoUpload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadControlLogoUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControlLogo", LogoUploadControllerUploadControlLogoSettings.UploadValidationSettings, LogoUploadControllerUploadControlLogoSettings.FileUploadComplete);
            return null;
        }

        [HttpPost]
        public ActionResult BurayaGonder(string tbxLogoUrl)
        {
            return RedirectToAction(nameof(this.Index));
        }

    }
    
    public class LogoUploadControllerUploadControlLogoSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg" },
            MaxFileSize = 4000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                // Save uploaded file to some location
                var fileName = e.UploadedFile.FileName;
                var extension = fileName.Substring(fileName.LastIndexOf('.') + 1);
                var folder = "~/Content/Logo/";
                var generatedFileName = DateTime.Now.Ticks.ToString() + "." + extension;
                e.UploadedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(folder) + generatedFileName); // Dosyayi istedigin yere kaydeder
                e.CallbackData = folder + generatedFileName;

            }
        }
    }

}