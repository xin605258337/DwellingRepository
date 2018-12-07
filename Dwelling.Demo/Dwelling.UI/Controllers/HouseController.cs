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
        /// <summary>
        /// 添加房源view
        /// </summary>
        /// <returns></returns>
        public ActionResult AddHouse()
        {
            return View();
        }

        

       
    }
}