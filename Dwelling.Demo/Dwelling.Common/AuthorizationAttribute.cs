using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dwelling.Common
{
    using System.Web;
    using System.Web.Security;
    using Newtonsoft.Json;
    using Model;
    using System.Web.Http.Controllers;
    using System.Web.Mvc;

    public class AuthorizationAttribute: AuthorizeAttribute
    {
         /// <summary>
         /// 授权过滤方法
         /// </summary>
         /// <param name="filterContext">授权上下文</param>
         public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //已认证用户
                var strUserData = ((FormsIdentity)filterContext.HttpContext.User.Identity).Ticket.UserData;
                var _loginInfo = JsonConvert.DeserializeObject<Admin>(strUserData);
                _loginInfo = RedisHelper.Get<Admin>(_loginInfo.Admin_ID.ToString());

                var action = filterContext.RouteData.Values["Action"];
                var controller = filterContext.RouteData.Values["Controller"];
                var tmpVal = (controller + "/" + action).ToLower();

                //filterContext.HttpContext.Response.Redirect("/student/index");
            }
            else
            {
                FormsAuthentication.SignOut();
            }

            // if (filterContext.HttpContext.Session["UserInfo"] == null)
            // {
            //      filterContext.HttpContext.Response.Redirect("/home/login");
            //  }
        }
    }
}
