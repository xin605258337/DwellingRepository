using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //管理员接口
    public interface IAdminService
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <returns></returns>
        Admin adminLogin(Admin admin);
        /// <summary>
        /// 获取所有普通管理员
        /// </summary>
        /// <returns></returns>
        List<Admin> GetAdmins();
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        int AddAdmin(Admin admin);
        /// <summary>
        /// 删除管理员信息
        /// </summary>
        /// <returns></returns>
        int DeleteAdmin(int adminId);
    }
}
