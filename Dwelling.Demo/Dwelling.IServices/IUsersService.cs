using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //用户接口
    public interface IUsersService
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        List<Users> GetUsers();
    }
}
