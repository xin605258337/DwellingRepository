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
            parameters.Add("_House_Describe", house.House_Describe);
            parameters.Add("_HabitableRoom_ID", house.HabitableRoom_ID);
            parameters.Add("_Region_ID", house.Region_ID);
            parameters.Add("_Street_ID", house.Street_ID);
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
            parameters.Add("_House_Num", house.House_Num);
            parameters.Add("_House_IsEnable", house.House_IsEnable);

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
        public HouseDetails GetHouseByID(int houseId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ID", houseId);
            return conn.Query<HouseDetails>("pro_GetHouseByID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        /// <summary>
        /// 获取所有房源信息
        /// </summary>
        /// <returns></returns>
        public List<HouseDetails> GetHouses(string houseName = "", string regionId="", int buildingTypeId = 0, int habitableRoomId = 0, int leaseTypeId = 0, int Orientation = 0, int styleId = 0)
        {
            List<HouseDetails> houseDetailsList = conn.Query<HouseDetails>("proc_GetHouse", null, commandType: CommandType.StoredProcedure).ToList();
            //判断模糊查询
            if(!string.IsNullOrEmpty(houseName))
            {
                houseDetailsList = houseDetailsList.Where(n => n.House_Name.Contains(houseName)).ToList();
            }
            //判断地区
            if (!string.IsNullOrEmpty(regionId))
            {
                houseDetailsList = houseDetailsList.Where(n => n.Region_ID.Equals(regionId)).ToList();
            }
            //房源类型(电梯楼或楼梯楼)
            if (buildingTypeId!=0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.BuildingType_ID.Equals(buildingTypeId)).ToList();
            }
            //户型
            if (habitableRoomId != 0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.HabitableRoom_ID.Equals(habitableRoomId)).ToList();
            }
            //出租类型
            if (leaseTypeId != 0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.LeaseType_ID.Equals(leaseTypeId)).ToList();
            }
            //朝向
            if (Orientation != 0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.Orientation_ID.Equals(Orientation)).ToList();
            }
            //房源装修风格
            if (styleId != 0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.Style_ID.Equals(styleId)).ToList();
            }

            return houseDetailsList;
        }
        /// <summary>
        /// 根据添加房源的第一张图片url获得房源ID
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public int GetHouseIdByImgUrl(string imgUrl)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ImgUrl", imgUrl);
            House house= conn.Query<House>("pro_GetHouseIDByImgurl", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return house.House_ID;
        }
        /// <summary>
        /// 获取热门房源排序
        /// </summary>
        /// <returns></returns>
        public List<HouseDetails> GetHotHouses()
        {
            return conn.Query<HouseDetails>("GetHotHouse", null, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// 修改房源点击数
        /// </summary>
        /// <param name="clickNum"></param>
        /// <param name="houseId"></param>
        /// <returns></returns>
        public int UpdateHouseClickNum(int clickNum,int houseId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ClickNum", clickNum);
            parameters.Add("_House_ID", houseId);
            return conn.Execute("pro_UpdateClickNum", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 根据出租类型获取房源
        /// </summary>
        /// <param name="leaseTypeName"></param>
        /// <returns></returns>
        public List<HouseDetails> GetHouseByLeaseType(string leaseTypeName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_LeaseType_Name", leaseTypeName);
            return conn.Query<HouseDetails>("pro_GetHouseByLeaseType", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// 根据区分组查询点击量
        /// </summary>
        /// <returns></returns>
        public List<House> GetECharts()
        {
            return conn.Query<House>("proc_GetECharts", null, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// 修改发布房源是否启用 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="House_IsEnable"></param>
        /// <returns></returns>
        public int updateHouseIsEnable(int id, int House_IsEnable)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ID", id);
            parameters.Add("_House_IsEnable", House_IsEnable);
            return conn.Execute("proc_updateHouse", parameters, commandType: CommandType.StoredProcedure);
        }
        
        /// <summary>
        /// 获取所有房源信息
        /// </summary>
        /// <returns></returns>
        public List<HouseDetails> GetHotHousesbyenable(string houseName = "", string regionId = "", int buildingTypeId = 0, int habitableRoomId = 0, int leaseTypeId = 0, int Orientation = 0, int styleId = 0)
        {
            List<HouseDetails> houseDetailsList = conn.Query<HouseDetails>("proc_GetHouse1", null, commandType: CommandType.StoredProcedure).ToList();
            //判断模糊查询
            if (!string.IsNullOrEmpty(houseName))
            {
                houseDetailsList = houseDetailsList.Where(n => n.House_Name.Contains(houseName)).ToList();
            }
            //判断地区
            if (!string.IsNullOrEmpty(regionId))
            {
                houseDetailsList = houseDetailsList.Where(n => n.Region_ID.Equals(regionId)).ToList();
            }
            //房源类型(电梯楼或楼梯楼)
            if (buildingTypeId != 0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.BuildingType_ID.Equals(buildingTypeId)).ToList();
            }
            //户型
            if (habitableRoomId != 0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.HabitableRoom_ID.Equals(habitableRoomId)).ToList();
            }
            //出租类型
            if (leaseTypeId != 0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.LeaseType_ID.Equals(leaseTypeId)).ToList();
            }
            //朝向
            if (Orientation != 0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.Orientation_ID.Equals(Orientation)).ToList();
            }
            //房源装修风格
            if (styleId != 0)
            {
                houseDetailsList = houseDetailsList.Where(n => n.Style_ID.Equals(styleId)).ToList();
            }

            return houseDetailsList;
        }

    }
}
