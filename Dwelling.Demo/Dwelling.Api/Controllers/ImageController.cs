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
    public class ImageController : ApiController
    {
        [Dependency]
        public IImageService imageService { get; set; }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AddImg")]
        public int AddImg(int houseId, string imgUrl)
        {
            return imageService.AddImg(houseId,imgUrl);
        }
    }
}
