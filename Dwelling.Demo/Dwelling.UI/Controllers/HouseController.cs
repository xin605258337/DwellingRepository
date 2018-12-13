using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Dwelling.UI.Controllers
{
    public class HouseController : Controller
    {

        // GET: House
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetImg()
        {
            List<string> pathList = new List<string>();
            var num = HttpContext.Request.Files.Count;
            for (int i = 0; i < num; i++)
            {
                HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[i];
                //上传的文件保存到目录(为了保证文件名不重复，加个Guid)
                string path = "~/Content/Img/" + Guid.NewGuid().ToString() + file.FileName;
                file.SaveAs(HttpContext.Request.MapPath(path));//必须得是相对路径
                pathList.Add(path);
            }
            return Json(pathList);
        }  
    }
}