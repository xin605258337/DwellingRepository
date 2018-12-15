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
    //角色权限Services
    public class RolePermissionService: IRolePermissionService
    {
        //连接数据库字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public RolePermissionService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加角色权限表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int AddRolePermission(int roleId,int permission)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Role_ID", roleId);
            parameters.Add("_Permission_ID", permission);
            return conn.Execute("pro_AddRolePermission", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
