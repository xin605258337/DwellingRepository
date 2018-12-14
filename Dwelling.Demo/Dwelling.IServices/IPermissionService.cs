using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    public  interface IPermissionService
    {
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        int addPermission(Permission permission);
        /// <summary>
        /// 权限展示
        /// </summary>
        /// <returns></returns>
        List<Permission> GetPermissions();

        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="Permissions_id"></param>
        /// <returns></returns>
        int delPermissions(int id);
    }
}
