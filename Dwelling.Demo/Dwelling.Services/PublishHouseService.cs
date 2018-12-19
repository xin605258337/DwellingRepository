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

    public class PublishHouseService : IPublishHouseService
    {

        //连接数据库字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;

        public PublishHouseService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }

        public int AddPublishHouse(PublishHouse house)
        {
            //存储过程参数
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_PublishHouse_ID", house.PublishHouse_ID);
            parameters.Add("_HabitableRoom_ID", house.HabitableRoom_ID);
            parameters.Add("_PublishHouse_Num",house.PublishHouse_Num);
            parameters.Add("_PublishHouse_Area", house.PublishHouse_Area);
            parameters.Add("_Orientation_ID", house.Orientation_ID);
            parameters.Add("_Style_ID", house.Style_ID);
            parameters.Add("_PublishHouse_RentMoney", house.PublishHouse_RentMoney);
            parameters.Add("_PublishHouse_Floor", house.PublishHouse_Floor);
            parameters.Add("_PublishHouse_SumFloor", house.PublishHouse_SumFloor);
            parameters.Add("_BuildingType_ID", house.BuildingType_ID);
            parameters.Add("_PublishHouse_RentTimeBegin", house.PublishHouse_RentTimeBegin);
            parameters.Add("_PublishHouse_RentTimeEnd", house.PublishHouse_RentTimeEnd);
            parameters.Add("_PublishHouse_ImgUrl", house.PublishHouse_ImgUrl);
            parameters.Add("_PublishHouse_Description", house.PublishHouse_Description);
            parameters.Add("_PublishHouse_Facility", house.PublishHouse_Facility);
            parameters.Add("_LeaseType_ID", house.LeaseType_ID);
            parameters.Add("_PublishHouse_Payment", house.PublishHouse__Payment);
            parameters.Add("_PublishHouse_Owner", house.PublishHouse_Owner);
            parameters.Add("_PublishHouse_OwnerTel", house.PublishHouse_OwnerTel);
            int result = conn.Execute("proc_addPublishHouse", parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
        /// <summary>
        /// 删除房源
        /// </summary>
        /// <param name="PublishHouseID"></param>
        /// <returns></returns>
        public int deletePublishHouse(int PublishHouseID)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PublishHouseid", PublishHouseID);
            return conn.Execute("proc_deletePublishHouse", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 显示房源
        /// </summary>
        /// <returns></returns>
        public List<PublishHouse> GetPublishHouse()
        {
            return conn.Query<PublishHouse>("proc_getPublishHouse", null, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
