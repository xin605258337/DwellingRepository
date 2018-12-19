using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dwelling.Api.Controllers
{
    using Unity;
    using Unity.Attributes;
    using Dwelling.IServices;
    using Dwelling.Model;
    using Dwelling.Common;
    [RequestAuthorization]
    [RoutePrefix("Dwelling")]
    public class AdminRoleController : ApiController
    {
        [Dependency]
        public IAdminRoleService adminRoleService { get; set; }
        /// <summary>
        /// 添加管理员角色表
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AddAdminRole")]
        public int AddAdminRole(int roleId,int AdminId)
        {
            AdminRole adminRole = new AdminRole();
            adminRole.Admin_ID = AdminId;
            adminRole.Role_ID = roleId;
            return adminRoleService.AddAdminRole(adminRole);
        }
    }
}
