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
    //足迹Service
    public class TrackService : ITrackService
    {
        //连接数据库字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public TrackService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加足迹
        /// </summary>
        /// <returns></returns>
        public int AddTrack(Track track)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ID", track.House_ID);
            parameters.Add("_Users_ID", track.Users_ID);
            return conn.Execute("pro_AddTrack", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
