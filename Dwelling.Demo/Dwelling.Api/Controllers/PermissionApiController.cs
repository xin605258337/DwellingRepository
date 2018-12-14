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
    [RoutePrefix("Dwelling")]
    public class PermissionApiController : ApiController
    {
        [Dependency]
        public IPermissionService PermissionService { get; set; }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addPermission")]
        public int addPermission(Permission permission)
        {
            return PermissionService.addPermission(permission);
        }
        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="Permissions_id"></param>
        /// <returns></returns>
       [HttpGet]
       [Route("delPermissions")]
        public int delPermissions(int id)
        {
            return PermissionService.delPermissions(id);
        }
        /// <summary>
        /// 查看权限信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPermissions")]
        public List<Permission> GetPermissions()
        {
            return PermissionService.GetPermissions();
        }

        }
}
