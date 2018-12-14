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
    public class RolePermissionService : IRolePermissionService
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
        public int RolePermission(List<RolePermission>  rolePermission)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = string.Format("insert  into rolepermission(Rolepermission_ID,permission_ID,role_ID ) values(@Rolepermission_ID,@permission_ID,@role_ID )");
                int n = conn.Execute(sql, rolePermission);
                return n;
            }
        }
    }
}
