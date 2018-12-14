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
        public int delPermissions(int Permissions_id)
        {
            return PermissionService.delPermissions(Permissions_id);
        }
        /// <summary>
        /// 查看权限信息
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetPermissions()
        {
            return PermissionService.GetPermissions();
        }

        }
}
