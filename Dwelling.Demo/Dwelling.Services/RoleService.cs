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
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoles()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn.Query<Role>("pro_GetRole", null, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// 根据添加角色名字和备注角色ID
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="roleRemark"></param>
        /// <returns></returns>
        public Role GetRoleByName(string roleName,string roleRemark)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Role_Name", roleName);
            parameters.Add("_Role_Remark", roleRemark);
            return conn.Query<Role>("pro_GetRoleByName", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        /// <summary>
        /// 删除角色显示
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public int DeleteRole(int roleId)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Role_ID", roleId);
            return conn.Execute("pro_DeleteRole", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int AddRole(Role role)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Role_Name", role.Role_Name);
            parameters.Add("_Role_Remark", role.Role_Remark);
            return conn.Execute("pro_AddRole", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
