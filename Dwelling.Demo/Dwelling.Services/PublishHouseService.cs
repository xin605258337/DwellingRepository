﻿using System;
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
            parameters.Add("@HabitableRoom_ID", house.HabitableRoom_ID, DbType.Int32, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_Num", house.PublishHouse_Num, DbType.String, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_Area", house.PublishHouse_Area, DbType.Double, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_RentMoney", house.PublishHouse_RentMoney, DbType.Decimal, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_Floor", house.PublishHouse_Floor, DbType.Int32, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_SumFloor", house.PublishHouse_SumFloor, DbType.Int32, ParameterDirection.Input, null);
            parameters.Add("@BuildingType_ID", house.BuildingType_ID, DbType.Int32, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_RentTimeBegin", house.PublishHouse_RentTimeBegin, DbType.DateTime, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_RentTimeEnd", house.PublishHouse_RentTimeEnd, DbType.DateTime, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_Img", house.PublishHouse_ImgUrl, DbType.Int32, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_Description", house.PublishHouse_Description, DbType.String, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse_Facility", house.PublishHouse_Facility, DbType.String, ParameterDirection.Input, null);
            parameters.Add("@LeaseType_ID", house.LeaseType_ID, DbType.Int32, ParameterDirection.Input, null);
            parameters.Add("@Style_ID", house.Style_ID, DbType.Int32, ParameterDirection.Input, null);
            parameters.Add("@PublishHouse__Payment", house.PublishHouse__Payment, DbType.String , ParameterDirection.Input, null);
            parameters.Add("@ApprovalStatic", house.ApprovalStatic, DbType.Int32, ParameterDirection.Input, null);
            int result = conn.Execute("addPublishHouse", parameters, commandType: CommandType.StoredProcedure);
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
