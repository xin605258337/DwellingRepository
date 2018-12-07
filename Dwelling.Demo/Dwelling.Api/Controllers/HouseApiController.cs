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
    [RoutePrefix("Dwelling")]
    public class HouseApiController : ApiController
    {
        [Dependency]
        public IHouseService HouseService { get; set; }
        /// <summary>
        /// 添加房源
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddHouse")]
        public int AddHouse(House house)
        {
            return HouseService.AddHouse(house);
        }
        /// <summary>
        /// 根据ID删除房源信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteHouse")]
        public int DeleteHouse(int houseId)
        {
            return HouseService.DeleteHouse(houseId);
        }
        /// <summary>
        /// 根据房源ID获取房源信息
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHouseByID")]
        public House GetHouseByID(int houseId)
        {
            return HouseService.GetHouseByID(houseId);
        }
        /// <summary>
        /// 获取所有房源信息s
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHouses")]
        public List<House> GetHouses()
        {
            return HouseService.GetHouses();
        }

    }
}
