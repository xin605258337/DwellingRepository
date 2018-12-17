using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Services
{
    using System.Configuration;
    using Dwelling.Model;
    using MySql.Data;
    using MySql.Data.MySqlClient;
    using System.Data;
    using Dapper;
    using Dwelling.IServices;
    //管理员角色Service
    public class AdminRoleService: IAdminRoleService
    {
        //连接数据库字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public AdminRoleService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加管理员角色表
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int AddAdminRole(AdminRole adminRole)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Role_ID", adminRole.Role_ID);
            parameters.Add("_Admin_ID", adminRole.Admin_ID);
            return conn.Execute("pro_AddAdminRole", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
