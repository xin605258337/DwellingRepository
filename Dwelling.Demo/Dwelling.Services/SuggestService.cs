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
    public class SuggestService : ISuggestService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;

        MySqlConnection conn = null;

        public SuggestService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加建议
        /// </summary>
        /// <param name="suggest"></param>
        /// <returns></returns>
        public int AddSuggest(Suggest suggest)
        {
        
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Suggest_Content", suggest.Suggest_Content);
            //parameters.Add("_Suggest_Img", suggest.Suggest_Content);
            //parameters.Add("_Users_ID", suggest.Suggest_Content);
            return conn.Execute("proc_AddSuggest", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Suggest GetSuggestByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_suggestID", id);
            return conn.Query<Suggest>("proc_GetSuggestByID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        /// <summary>
        /// 获取建议表信息
        /// </summary>
        /// <returns></returns>
        public List<Suggest> GetSuggests()
        {          
            return conn.Query<Suggest>("proc_GetSuggestAll", null, commandType: CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// 修改建议表信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_Suggest_Result"></param>
        /// <returns></returns>
        public int UpdateSuggest(int id, string _Suggest_Result)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Suggest_ID", id);
            parameters.Add("_Suggest_Result", _Suggest_Result);
            return conn.Execute("proc_UpdateSuggest", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}


