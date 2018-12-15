using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    //角色权限接口
    public interface IRolePermissionService
    {
        /// <summary>
        /// 添加角色权限表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        int AddRolePermission(int roleId, int permission);
    }
}
