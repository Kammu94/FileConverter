using Aspose.Words;
using FileConverter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FileConverter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
         
            return View();
        }
        public ActionResult  FirstCall(string[] args)
        {
            var json = @"{
                       ""employees"": [
                       { ""firstName"":""John"" , ""lastName"":""Doe"" },
                       { ""firstName"":""Anna"" , ""lastName"":""Smith"" },
                       { ""firstName"":""Peter"" , ""lastName"":""Jones"" }
                       ]
                       }";
            GetDataTableFromJsonString(json);

            return View();
        }

        public DataTable GetDataTableFromJsonString(string json)
        {
            var jsonLinq = JObject.Parse(json);

            // Find the first array using Linq  
            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();
            foreach (JObject row in srcArray.Children<JObject>())
            {
                var cleanRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    // Only include JValue types  
                    if (column.Value is JValue)
                    {
                        cleanRow.Add(column.Name, column.Value);
                    }
                }
                trgArray.Add(cleanRow);
            }
            var a = JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
            return a;
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
        public ActionResult ConvertPDFintoDOCX(HttpPostedFileBase postedFile)
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
                postedFile.SaveAs(PDFfileSavePath.ToString());
                Document doc = new Document(fileSavePath.ToString());
                doc.Save(fileSavePath.ToString() + ".doc");
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