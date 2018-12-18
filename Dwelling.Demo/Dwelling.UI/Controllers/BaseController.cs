using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dwelling.UI.Controllers
{
    using Dwelling.Model;
    using Newtonsoft.Json;
    using System.Web.Security;
    using Dwelling.Common;
    using System.Text;

    public class BaseController : Controller
    {
        private Admin admin;
        // GET: Base
        public Admin LoginInfo
        {
            get
            {
                //当前请求的用户身份是否合法
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var strUserData = ((FormsIdentity)User.Identity).Ticket.UserData;
                    admin = JsonConvert.DeserializeObject<Admin>(strUserData);

                    admin = RedisHelper.Get<Admin>(admin.Admin_ID.ToString());
                }
                return admin;
            }
        }

        /// <summary>
        /// 用户登录成功后，将用户信息缓存起来
        /// </summary>
        /// <param name="userData"></param>
        public static void WriteDataToCookie(Admin admin)
        {
            //将实体对象序列化为json字符串
            var strUserData = JsonConvert.SerializeObject(admin);

            //将json字符串生成对应的令牌数据  persistent 持久化
            var ticket = new FormsAuthenticationTicket(1, admin.Admin_ID.ToString(), DateTime.Now, DateTime.Now.AddHours(12), false, strUserData);
            var ticketVal = FormsAuthentication.Encrypt(ticket);

            CookiesHelper.SetCookie(FormsAuthentication.FormsCookieName, ticketVal, ticket.Expiration);

            RedisHelper.Set<Admin>(admin.Admin_ID.ToString(), admin);
        }

        /// <summary>
        /// 动作过滤器-动作执行之前的事件
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.LoginInfo = LoginInfo;

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 异常过滤器
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                base.OnException(null);
                return;
            }

            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();
            var timeStamp = filterContext.HttpContext.Timestamp;

            var parmId = string.Empty;
            if (filterContext.RouteData.Values["id"] != null)
            {
                parmId = filterContext.RouteData.Values["id"].ToString();
            }
        }
    }
}