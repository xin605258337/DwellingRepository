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

    public class HabitableRoomServices : IHabitableroomServices
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public HabitableRoomServices()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 获取户型信息
        /// </summary>
        /// <returns></returns>
        public List<HabitableRoom> GetHabitableRoom()
        {
            List<HabitableRoom> habitableRooms = conn.Query<HabitableRoom>("proc_gethabitableroom", null, commandType: CommandType.StoredProcedure).ToList();
            return habitableRooms;
        }

    }
}
