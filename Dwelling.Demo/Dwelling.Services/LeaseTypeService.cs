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
    public class LeaseTypeService:ILeaseTypeService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public LeaseTypeService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }

        /// <summary>
        /// 获取房源朝向信息
        /// </summary>
        /// <returns></returns>
        public List<LeaseType> GetLeaseType()
        {
            return conn.Query<LeaseType>("proc_getleasetype", null, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
