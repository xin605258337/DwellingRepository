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
        //连接数据库字符串
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
            using (MySqlConnection conn = new MySqlConnection (connStr))
            {
                conn.Open();
                string sql = string.Format("insert  into permission(permission_ID,permission_Name,permission_Url,Pid,enable,rank,remark) values(@permission_ID,@permission_Name,@permission_Url,@Pid,@enable,@rank,@remark)");
                int n = conn.Execute(sql, permission);
                return n;
            }
        }



        public int delPermissions(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = string.Format("delete from permission where permission_ID=@pid");
                int n = conn.Execute(sql, new { pid=id});
                return n;

            }
            }

        public List<Permission> GetPermissions()
        {
            using (MySqlConnection conn = new MySqlConnection (connStr))
            {
                conn.Open();
                string sql = string.Format("select * from permission");
                IEnumerable<Permission> result = conn.Query<Permission>(sql, null);


                return result.ToList<Permission>();
            }
        }
    }
}
