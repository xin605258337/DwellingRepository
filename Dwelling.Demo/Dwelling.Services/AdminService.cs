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
        public Admin adminLogin(Admin admin)
        {
            conn.Open();
            //存储过程参数
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@_Admin_Name", admin.Admin_Name);
            parameters.Add("@_Admin_Password", admin.Admin_Password);
            var ad= conn.Query<Admin>("pro_AdminLogin", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            conn.Close();
            //获取admin
            return ad;
        }
        
        /// <summary>
        /// 获取所有普通管理员
        /// </summary>
        /// <returns></returns>
        public List<Admin> GetAdmins()
        {
            conn.Open();
            var ad = conn.Query<Admin>("proc_getadmins", null, commandType: CommandType.StoredProcedure).ToList();
            conn.Close();
            return ad;
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int AddAdmin(Admin admin)
        {
            conn.Open();
            //存储过程参数
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@_Admin_ID", admin.Admin_ID);
            parameters.Add("@_Admin_Name", admin.Admin_Name);
            parameters.Add("@_Admin_Password", admin.Admin_Password);
            parameters.Add("@_Admin_number", admin.Admin_number);
            parameters.Add("@_Admin_Permission", admin.Admin_Permission);
            parameters.Add("@_Admin_remark", admin.Admin_remark);
            parameters.Add("@_Admin_email", admin.Admin_email);
            parameters.Add("@_Admin_sex", admin.Admin_sex);
            var addadmin= conn.Execute("proc_addadmins", parameters, commandType: CommandType.StoredProcedure);
            conn.Close();
            return addadmin;
        }
        /// <summary>
        /// 删除管理员信息
        /// </summary>
        /// <returns></returns>
        public int DeleteAdmin(int adminId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@_Admin_ID",adminId);
            return conn.Execute("pro_DeleteAdmin", parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
