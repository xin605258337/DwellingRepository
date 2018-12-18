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
            parameters.Add("_Complain_ID", complain.Complain_ID);
            parameters.Add("_Complain_Content", complain.Complain_Content);
            //parameters.Add("_Complain_Time", complain.Complain_Time);
            //parameters.Add("_Complain_Result", complain.Complain_Result);
            //parameters.Add("_Users_ID", complain.Complain_ID);
            //parameters.Add("_ApprovalStatic", complain.ApprovalStatic);
            return conn.Execute("proc_AdddComplain", parameters, commandType: CommandType.StoredProcedure);
        }

        public List<Complain> GetComplains()
        {
            throw new NotImplementedException();
        }
    }
}
