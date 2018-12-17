using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //管理员角色接口
    public interface IAdminRoleService
    {
        /// <summary>
        /// 添加管理员角色表
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        int AddAdminRole(AdminRole adminRole);
    }
}
