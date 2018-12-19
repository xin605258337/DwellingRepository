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
    [RequestAuthorization]
    [RoutePrefix("Dwelling")]
    public class ImageController : ApiController
    {
        [Dependency]
        public IImageService ImageService { get; set; }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AddImg")]
        public int AddImg(int houseId, string imgUrl)
        {
            return ImageService.AddImg(houseId, imgUrl);
        }
        /// <summary>
        /// 根据房源ID获取房源所有图片
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetImageByHouseId")]
        public List<Image> GetImageByHouseId(int houseId)
        {
            return ImageService.GetImageByHouseId(houseId);
        }
    }
}
