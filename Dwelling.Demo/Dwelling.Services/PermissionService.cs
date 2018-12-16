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
        public int AddPermission(Permission permission)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Permission_Name", permission.Permission_Name);
            parameters.Add("_Permission_Url", permission.Permission_Url);
            parameters.Add("_Permission_Enabel", permission.Permission_Enabel);
            parameters.Add("_Permission_Remark", permission.Permission_Remark);
            parameters.Add("_pID", permission.pID);
            return conn.Execute("pro_AddPermission", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelPermissions(int permissionId)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Permission_ID", permissionId);
            return conn.Execute("pro_DeletePermission", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetPermissions()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn.Query<Permission>("pro_GetPermission", null, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// 获得权限所有父节点
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetPermissionPid()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn.Query<Permission>("pro_GetPermissionPid", null, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
