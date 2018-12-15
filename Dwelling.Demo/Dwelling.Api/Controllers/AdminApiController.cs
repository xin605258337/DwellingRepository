using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
namespace Dwelling.Api.Controllers
{
    using Unity;
    using Unity.Attributes;
    using Dwelling.IServices;
    using Dwelling.Model;
    [RoutePrefix("Dwelling")]
    
    public class AdminApiController : ApiController
    {
        [Dependency]
        public IAdminService AdminService { get; set; }
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AdminLogin")]
        public Admin AdminLogin(Admin admin)
        {
            return AdminService.AdminLogin(admin);
        }
        /// <summary>
        /// 获取所有普通管理员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAdmins")]
        public List<Admin> GetAdmins()
        {
            return AdminService.GetAdmins();
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddAdmin")]
        public int AddAdmin(Admin admin)
        {
            return AdminService.AddAdmin(admin);
        }
        /// <summary>
        /// 删除管理员信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteAdmin")]
        public int DeleteAdmin(int adminId)
        {
            return AdminService.DeleteAdmin(adminId);
        }
        /// <summary>
        /// 获取管理员权限(url)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAdminPermissionUrls")]
        public List<Admin> GetAdminPermissionUrls(int adminId)
        {
            return AdminService.GetAdminPermissionUrls(adminId);
        }
    }
}
