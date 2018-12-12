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
     public class PriceService:IPriceService
    {

        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public PriceService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }

        /// <summary>
        /// 获取价格范围信息
        /// </summary>
        /// <returns></returns>
        public List<Price> GetPrice()
        {
            return conn.Query<Price>("proc_getprice", null, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
