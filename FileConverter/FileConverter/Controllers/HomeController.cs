using Aspose.Words;
using FileConverter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace FileConverter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
         
            return View();
        }
        public ActionResult FileUploadWord(HttpPostedFileBase postedFile)
        {
            if (postedFile != null)
            {
                object documentFormat = 8;
                string randomName = DateTime.Now.Ticks.ToString();
                object htmlFilePath = Server.MapPath("~/HTMLWordFiles/") + randomName + ".htm";
                string directoryPath = Server.MapPath("~/WordFiles/") + randomName + "_files";
                object fileSavePath = Server.MapPath("~/WordFiles/") + Path.GetFileName(postedFile.FileName);
                object PDFfileSavePath = Server.MapPath("~/PDFFiles/") + Path.GetFileName(postedFile.FileName);

                //If Directory not present, create it.
                if (!Directory.Exists(Server.MapPath("~/HTMLWordFiles/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/HTMLWordFiles/"));
                }
                postedFile.SaveAs(fileSavePath.ToString());
                Document doc = new Document(fileSavePath.ToString());
                doc.Save(PDFfileSavePath.ToString() + ".pdf");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}