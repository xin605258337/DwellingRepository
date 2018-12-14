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
    public class RolePermissionApiController : ApiController
    {
        [Dependency]
        public IRolePermissionService RolePermissionService { get; set; }


        [HttpPost]
        [Route("addRolePermission")]
        public int RolePermission(RolePermission rolePermission)
        {

            return RolePermissionService.RolePermission(rolePermission);
        }
        }
}
