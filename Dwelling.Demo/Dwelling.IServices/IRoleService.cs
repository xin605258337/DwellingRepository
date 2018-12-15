using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    /// <summary>
    /// 角色接口
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        List<Role> GetRoles();
        /// <summary>
        /// 删除角色显示
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        int DeleteRole(int roleId);
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int AddRole(Role role);
    }
}
