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
        [HttpPost]
        [Route("addPermission")]
        public int addPermission(Permission permission)
        {
            return PermissionService.addPermission(permission);
        }
        [HttpGet]
        [Route("GetPermissions")]
        public List<Permission> GetPermissions()
        {
            return PermissionService.GetPermissions();
        }
        }
}
