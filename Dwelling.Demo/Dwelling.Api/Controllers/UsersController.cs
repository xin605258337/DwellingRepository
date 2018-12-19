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
    [RequestAuthorization]
    public class UsersController : ApiController
    {
        [Dependency]
        public IUsersService UsersService { get; set; }
        /// <summary>
        /// token密钥登录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("Logins")]
        public Users Logins(string code)
        {
            Token token = new Token();
            return token.Logins(code);
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            return UsersService.GetUsers();
        }

    }
}
