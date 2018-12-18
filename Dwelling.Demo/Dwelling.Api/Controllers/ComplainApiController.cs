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
    public class ComplainApiController : ApiController
    {
        [Dependency]
        public IComplainService ComplainService { get; set; }

        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="complain"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddComplain")]
        public int AddComplain(Complain complain)
        {
            return ComplainService.AddComplain(complain);
        }
        }
}
