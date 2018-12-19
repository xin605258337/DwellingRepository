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
    //图片表
    public class ImageService:IImageService
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public ImageService()
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
        public int AddImg(int houseId,string imgUrl)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ID", houseId);
            parameters.Add("_Image_Url", imgUrl);
            return conn.Execute("pro_AddImgs", parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 根据房源ID获取房源所有图片
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        public List<Image> GetImageByHouseId(int houseId)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_House_ID", houseId);
            return conn.Query<Image>("pro_GetImgByHouseId", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
