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
    public class StyleService:IStyleService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public StyleService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }

        /// <summary>
        /// 获取房源风格信息
        /// </summary>
        /// <returns></returns>
        public List<Style> GetStyle()
        {
            return conn.Query<Style>("proc_getstyle", null, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
