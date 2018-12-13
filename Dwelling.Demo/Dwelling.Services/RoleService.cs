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
    public class RoleService:IRoleService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public RoleService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int addRole(Role role)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = string.Format("insert  into Permission values(@role_ID,@role_Name,@permission_Name)");
                int addRole = conn.Execute(sql, role);
                return addRole;

            }
        }
        /// <summary>
        /// 显示角色
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRole()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = string.Format("select * from Role");
                IEnumerable<Role> result = conn.Query<Role>(sql, null);
                return result.ToList<Role>();
            }
        }


    }
}
