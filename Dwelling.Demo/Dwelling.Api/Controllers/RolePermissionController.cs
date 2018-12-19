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
    public class RolePermissionController : ApiController
    {
        [Dependency]
        public IRolePermissionService AdminService { get; set; }
        /// <summary>
        /// 添加角色权限表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AddRolePermission")]
        public int AddRolePermission(int roleId, int permission)
        {
            return AdminService.AddRolePermission(roleId, permission);
        }
    }
}
