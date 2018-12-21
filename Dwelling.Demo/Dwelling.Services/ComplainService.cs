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
    public class ComplainService:IComplainService
    {
        //连接数据库字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public ComplainService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="complain"></param>
        /// <returns></returns>
        public int AddComplain(Complain complain)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Complain_Content", complain.Complain_Content);
            parameters.Add("_Users_ID", complain.Users_ID);
            return conn.Execute("pro_AddComplain", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 获取投诉信息
        /// </summary>
        /// <returns></returns>
        public List<Complain> GetComplains()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn.Query<Complain>("proc_getComplain", null, commandType: CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// 根据用户ID获取投诉信息
        /// </summary>
        /// <param name="_Complain_ID"></param>
        /// <returns></returns>
        public List<Complain> GetComplainByUserID(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", userId);
            return conn.Query<Complain>("proc_getComplainById", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// 修改投诉
        /// </summary>
        /// <param name="complain"></param>
        /// <returns></returns>
        public int UpdateComplain(int id,string result)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Complain_ID",id);
            parameters.Add("_Complain_Result", result);
            return conn.Execute("pro_updateComplain", parameters, commandType: CommandType.StoredProcedure);
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Complain GetComplainByID(int complainID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Complain_ID", complainID);
            return conn.Query<Complain>("GetComplainByIDs", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
