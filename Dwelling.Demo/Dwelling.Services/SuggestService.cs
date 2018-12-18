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
        /// 获取建议表信息
        /// </summary>
        /// <returns></returns>
        public List<Suggest> GetSuggests()
        {          
            return conn.Query<Suggest>("proc_GetSuggest", null, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}


