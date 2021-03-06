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
    public class CollectService : ICollectService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public CollectService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加收藏表
        /// </summary>
        /// <param name="_House_ID"></param>
        /// <returns></returns>
        public int AddCollect(Collect collect)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ID", collect.House_ID);
            parameters.Add("_Users_ID", collect.Users_ID);
            return conn.Execute("pro_AddCollect", parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// 根据房源名称查询房源信息
        /// </summary>
        /// <param name="_House_Name"></param>
        /// <returns></returns>
        public House GetHouseByName(string _House_Name)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_Name", _House_Name);
            return conn.Query<House>("proc_GetHouseByName", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        /// <summary>
        /// 根据收藏的房源ID查询房源信息
        /// </summary>
        /// <returns></returns>
        public List<House> GetHousesByCollect()
        {
            return conn.Query<House>("proc_GetCollect", null, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// 根据用户ID获取用户收藏
        /// </summary>
        /// <returns></returns>
        public List<Collect> GetCollects(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Users_ID", userId);
            return conn.Query<Collect>("pro_GetCollectByUserId", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
