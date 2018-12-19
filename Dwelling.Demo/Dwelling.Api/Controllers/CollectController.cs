using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dwelling.Api.Controllers
{
    using Unity;
    using Unity.Attributes;
    using Dwelling.IServices;
    using Dwelling.Model;
    using Dwelling.Common;
    [RoutePrefix("Dwelling")]
    public class CollectController : ApiController
    {
        [Dependency]

        public ICollectService CollectService { get; set; }

        /// <summary>
        /// 添加收藏表
        /// </summary>
        /// <param name="_House_ID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AddCollect")]
        public int AddCollect(int houseId,int userId)
        {
            Collect collect = new Collect();
            collect.House_ID = houseId;
            collect.Users_ID = userId;
            return CollectService.AddCollect(collect);
        }

        /// <summary>
        /// 根据房源名称查询房源信息
        /// </summary>
        /// <param name="_House_Name"></param>
        /// <returns></returns>
        [Route("GetHouseByName")]
        [HttpGet]
        public House GetHouseByName(string _House_Name)
        {
            return CollectService.GetHouseByName(_House_Name);
        }

        /// <summary>
        /// 根据收藏的房源ID查询房源信息
        /// </summary>
        /// <returns></returns>
        [Route("GetHousesByCollect")]
        [HttpGet]
        public List<House> GetHousesByCollect()
        {
            return CollectService.GetHousesByCollect();
        }
    }
}
