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
    public class ComplainServiceApiController : ApiController
    {
        [Dependency]
        public IComplainService ComplainService { get; set; }

        /// <summary>
        /// 添加投诉表
        /// </summary>
        /// <param name="complain"></param>
        [HttpPost]
        [Route("AddComplain")]
        public int AddComplain(Complain complain)
        {
            return ComplainService.AddComplain(complain);
        }

        [HttpGet]
        [Route("GetComplains")]
        public List<Complain> GetComplains()
        {
            return ComplainService.GetComplains();
        }
        }
}
