using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Services
{
    using Dwelling.Model;
    using System.Configuration;
    using MySql.Data.MySqlClient;
    using Dapper;
    using System.Data;

    public class HouseService
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
            parameters.Add("_House_Img", house.House_Img);
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

            return conn.Execute("proc_HouseAdd", parameters, commandType: CommandType.StoredProcedure);
        }


        /// <summary>
        /// 根据ID删除房源信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteHouse(int id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ID", id);
            return conn.Execute("proc_HouseDelete", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
