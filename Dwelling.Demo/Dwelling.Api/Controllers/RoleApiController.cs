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
    public class RoleApiController : ApiController
    {
        [Dependency]
        public IRoleService RoleService { get; set; }

        /// <summary>
        /// 角色添加
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addRole")]
        public int addRole(Role role)
        {
            return RoleService.addRole(role);
        }


        /// <summary>
        /// 显示角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRole")]
        public List<Role> GetRole()
        {
            return RoleService.GetRole();
        }

        }
}
