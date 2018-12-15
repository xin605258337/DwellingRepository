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
        int AddPermission(Permission permission);
        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelPermissions(int permissionId);
        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        List<Permission> GetPermissions();



    }
}
