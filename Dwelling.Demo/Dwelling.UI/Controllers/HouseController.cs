using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// 添加房源view
        /// </summary>
        /// <returns></returns>
        public ActionResult AddHouse()
        {
            return View();
        }
        /// <summary>
        /// 多图片上传
        /// </summary>
        /// <param name="context"></param>
        [HttpPost]
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var num = context.Request.Files.Count;

            for (int i = 0; i < num; i++)
            {
                HttpPostedFile file = context.Request.Files[i];
                //上传的文件保存到目录(为了保证文件名不重复，加个Guid)
                string path = "~/Content/Img/" + Guid.NewGuid().ToString() + file.FileName;
                file.SaveAs(context.Request.MapPath(path));//必须得是相对路径

            }
            context.Response.Write("上传成功");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}