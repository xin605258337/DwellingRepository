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
    public class WxImageController : ApiController
    {
        [Dependency]
        public IWxImageService WxImageService { get; set; }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <returns></returns>
        [Route("AddImg")]
        [HttpGet]
        public int AddImg(int houseId, string imgUrl)
        {
            return WxImageService.AddImg(houseId, imgUrl);
        }
    }
}
