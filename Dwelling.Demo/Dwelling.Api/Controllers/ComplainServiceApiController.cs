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
    public class ComplainServiceApiController : ApiController
    {
        [Dependency]
        public IComplainService ComplainService { get; set; }

        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="complain"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AddComplain")]
        public int AddComplain(string content,int userId)
        {
            Complain complain = new Complain();
            complain.Complain_Content = content;
            complain.Users_ID = userId;
            return ComplainService.AddComplain(complain);
        }

        [HttpGet]
        [Route("GetComplains")]
        public List<Complain> GetComplains()
        {
            return ComplainService.GetComplains();
        }

        /// <summary>
        /// 根据用户ID获取投诉信息
        /// </summary>
        /// <param name="_Complain_ID"></param>
        /// <returns></returns>
        [Route("GetComplainByUserID")]
        [HttpGet]
        public List<Complain> GetComplainByUserID(int userId)
        {
            return ComplainService.GetComplainByUserID(userId);
        }

        /// <summary>
        /// 修改投诉
        /// </summary>
        /// <param name="complain"></param>
        /// <returns></returns>
        [Route("UpdateComplain")]
        [HttpGet]
        public int UpdateComplain(int id, string result)
        {
            return ComplainService.UpdateComplain(id, result);
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetComplainByID")]
        [HttpGet]
        public Complain GetComplainByID(int complainID)
        {
            return ComplainService.GetComplainByID(complainID);
        }
    }
}
