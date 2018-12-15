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
    //管理员Service
    public class AdminService:IAdminService
    {
        //连接数据库字符串
        private static readonly string connStr= ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public AdminService()
        { 
            if(conn==null)
            {
                conn = new MySqlConnection(connStr);
            }         
        }
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <returns></returns>
        public Admin AdminLogin(Admin admin)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Admin_Name", admin.Admin_Name);
            parameters.Add("_Admin_Password", admin.Admin_Password);
            return conn.Query<Admin>("pro_AdminLogin", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        
        /// <summary>
        /// 获取所有普通管理员
        /// </summary>
        /// <returns></returns>
        public List<Admin> GetAdmins()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn.Query<Admin>("pro_GetAdmins", null, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int AddAdmin(Admin admin)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Admin_Name", admin.Admin_Name);
            parameters.Add("_Admin_Password", admin.Admin_Password);
            parameters.Add("_Admin_Gender", admin.Admin_Gender);
            parameters.Add("_Admin_Tel", admin.Admin_Tel);
            parameters.Add("_Admin_Email", admin.Admin_Email);
            parameters.Add("_Role_ID", admin.Role_ID);
            parameters.Add("_Admin_Remark", admin.Admin_Remark);
            return conn.Execute("pro_AddAdmin", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 删除管理员信息
        /// </summary>
        /// <returns></returns>
        public int DeleteAdmin(int adminId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Admin_ID",adminId);
            return conn.Execute("pro_DeleteAdmin", parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
