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
    public class AreaService:IAreaService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public AreaService()
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
        public List<Area> GetArea()
        {
            return conn.Query<Area>("proc_getarea", null, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
