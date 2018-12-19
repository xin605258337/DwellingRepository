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
    using Dwelling.Common;
    [RequestAuthorization]
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
        [Route("AddPermission")]
        public int AddPermission(Permission permission)
        {
            return PermissionService.AddPermission(permission);
        }
        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DelPermissions")]
        public int DelPermissions(int permissionId)
        {
            return PermissionService.DelPermissions(permissionId);
        }
        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPermissions")]
        public List<Permission> GetPermissions()
        {
            return PermissionService.GetPermissions();
        }
        /// <summary>
        /// 获得权限所有父节点
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPermissionPid")]
        public List<Permission> GetPermissionPid()
        {
            return PermissionService.GetPermissionPid();
        }
    }
}
