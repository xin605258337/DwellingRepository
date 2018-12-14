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
        int AddRole(Role role);

        List<Role> GetRoles();

        int DeleteRole(int roleID);
    }
}
