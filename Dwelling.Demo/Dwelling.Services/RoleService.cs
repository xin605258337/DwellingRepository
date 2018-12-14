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
        //public int AddRole( string role_Name, string ids)
        //{

        //    using (MySqlConnection conn = new MySqlConnection(connStr))
        //    {
        //        conn.Open();
                
        //        string sql = string.Format("insert into role(role_Name) values(@role_Name)");
               
        //         conn.Execute(sql, role_Name);
        //        string str1 = "select role_ID from role order by role_ID desc";
        //        int n=  conn.Query<int>(str1,null).FirstOrDefault();
        //        List<RolePermission> rolePermissions = new List<RolePermission>();
        //        foreach (var item in ids.ToArray())
        //        {
        //            RolePermission rolePermission = new RolePermission();
        //            rolePermission.role_ID = n;
        //            rolePermission.Rolepermission_ID = item;
        //            rolePermissions.Add(rolePermission);
        //        }
        //        string str2 = string.Format("insert  into RolePermission(role_ID,Rolepermission_ID) values(@role_ID,@Rolepermission_ID)");
        //        int n1=  conn.Execute(str2, rolePermissions);
        //        return n1;
        //    }

        //}
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoles()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = string.Format("select role_ID,role_Name,permission_Name from role");
                return conn.Query<Role>(sql, null).ToList();
            }
        }
        /// <summary>
        /// 删除角色显示
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public int DeleteRole(int roleID)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = string.Format("delete from role where role_ID=@roleID");
                return conn.Execute(sql,new { roleID = roleID });
            }
        }

        public int AddRole(Role role)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = string.Format("insert into role(role_Name,permission_Name) values(@role_Name,@permission_Name)");
                return conn.Execute(sql, role);
            }
        }
    }
}
