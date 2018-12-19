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
    public class RoleApiController : ApiController
    {
        [Dependency]
        public IRoleService roleService { get; set; }
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRoles")]
        public List<Role> GetRoles()
        {
            return roleService.GetRoles();
        }
        /// <summary>
        /// 根据添加角色名字和备注角色ID
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="roleRemark"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRoleByName")]
        public Role GetRoleByName(string roleName, string roleRemark)
        {
            return roleService.GetRoleByName(roleName, roleRemark);
        }
        /// <summary>
        /// 删除角色显示
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteRole")]
        public int DeleteRole(int roleId)
        {
            return roleService.DeleteRole(roleId);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRole")]
        public int AddRole(Role role)
        {
            return roleService.AddRole(role);
        }
    }
}
