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
    public class PermissionService : IPermissionService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public PermissionService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int addPermission(Permission permission)
        {
            using (MySqlConnection conn = new  MySqlConnection (connStr))
            {
                conn.Open();
                string sql = string.Format("insert  into Permission values(@permission_ID,@permission_Name,@permission_Url,@Pid,@enable,@rank,@remark)");
                int addPermission = conn.Execute(sql, permission);
                return addPermission;

            }

        }
        /// <summary>
        /// 显示所有权限信息
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetPermissions()
        {

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = string.Format("select * from Permission");
                IEnumerable<Permission> result = conn.Query<Permission>(sql, null);
                return result.ToList<Permission>();
            }
            
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="Permissionid"></param>
        /// <returns></returns>
        public int delPermission(int Permissionid)
        {
            using (MySqlConnection conn = new MySqlConnection (connStr))
            {

                conn.Open();
                string sql = string.Format("delete from Permission where id=@Permissionid");
                int n = conn.Execute(sql, Permissionid);
                return n;

            }
        }

    }
}
