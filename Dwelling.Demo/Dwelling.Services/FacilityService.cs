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
    public class FacilityService:IFacilityService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public FacilityService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }

        /// <summary>
        /// 获取房源设施信息
        /// </summary>
        /// <returns></returns>
        public List<Facility> GetFacility()
        {
            return conn.Query<Facility>("proc_getfacility", null, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
