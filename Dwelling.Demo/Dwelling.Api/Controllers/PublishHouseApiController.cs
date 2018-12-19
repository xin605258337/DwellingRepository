using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dwelling.Api.Controllers
{
    using Unity.Attributes;
    using Dwelling.IServices;
    using Dwelling.Model;
    using Dwelling.Common;
    [RequestAuthorization]
    [RoutePrefix("Dwelling")]

    public class PublishHouseApiController : ApiController
    {
        [Dependency]
         public IPublishHouseService PublishHouseService { get; set; }

        /// <summary>
        /// 添加房源
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPublishHouse")]
        public int AddPublishHouse(PublishHouse house)
        {
            return PublishHouseService.AddPublishHouse(house);
        }
        /// <summary>
        /// 显示房源
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPublishHouse")]
        public List<PublishHouse> GetPublishHouse()
        {
            return PublishHouseService.GetPublishHouse();
        }
        /// <summary>
        /// 删除房源信息
        /// </summary>
        /// <param name="PublishHouseID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("deletePublishHouse")]
        public int deletePublishHouse(int PublishHouseID)
        {
            return PublishHouseService.deletePublishHouse(PublishHouseID);
        }


        }
}
