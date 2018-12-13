using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    public interface IRoleService
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int addRole(Role role);
        /// <summary>
        /// 显示角色信息
        /// </summary>
        /// <returns></returns>
        List<Role> GetRole();
    }
}
