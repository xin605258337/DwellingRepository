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

    public class HouseService:IHouseService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public HouseService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加房源
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        public int AddHouse(House house)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_Name", house.House_Name);
            parameters.Add("_House_ImgUrl", house.House_ImgUrl);
            parameters.Add("_House_Price", house.House_Price);
            parameters.Add("_HabitableRoom_ID", house.HabitableRoom_ID);
            parameters.Add("_House_Area", house.House_Area);
            parameters.Add("_Orientation_ID", house.Orientation_ID);
            parameters.Add("_Style_ID", house.Style_ID);
            parameters.Add("_House_Address", house.House_Address);
            parameters.Add("_LeaseType_ID", house.LeaseType_ID);
            parameters.Add("_House_Floor", house.House_Floor);
            parameters.Add("_House_SumFloor", house.House_SumFloor);
            parameters.Add("_BuildingType_ID", house.BuildingType_ID);
            parameters.Add("_House_Facility", house.House_Facility);
            parameters.Add("_House_RentTimeBegin", house.House_RentTimeBegin);
            parameters.Add("_House_RentTimeEnd", house.House_RentTimeEnd);
            parameters.Add("_House_Owner", house.House_Owner);
            parameters.Add("_House_OwnerTel", house.House_OwnerTel);
            parameters.Add("_House_OwnerWx", house.House_OwnerWx);
            parameters.Add("_House_RentMoney", house.House_RentMoney);
            parameters.Add("_House_Payment", house.House_Payment);

            return conn.Execute("proc_AddHouse", parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// 根据ID删除房源信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteHouse(int houseId)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ID", houseId);
            return conn.Execute("proc_DeleteHouse", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 根据房源ID获取房源信息
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        public House GetHouseByID(int houseId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ID", houseId);
            return conn.Query<House>("proc_GetHouseByID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        /// <summary>
        /// 获取所有房源信息
        /// </summary>
        /// <returns></returns>
        public List<House> GetHouses()
        {
            return conn.Query<House>("proc_GetHouse", null, commandType: CommandType.StoredProcedure).ToList();
        }
        
    }
}
