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
    //用户房源图片临时Service
    public class WxImageService:IWxImageService
    {
        //连接数据库字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public WxImageService()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <returns></returns>
        public int AddImg(int houseId, string imgUrl)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_WxHouse_ID", houseId);
            parameters.Add("_WxImage_Url", imgUrl);
            return conn.Execute("pro_AddWxImg", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
