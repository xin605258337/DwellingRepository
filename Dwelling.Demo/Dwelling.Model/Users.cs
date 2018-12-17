using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //用户名表
    public class Users
    {
        /// <summary>
        /// 用户名ID
        /// </summary>
        public int Users_ID { get; set; }
        /// <summary>
        /// 用户SessionKey
        /// </summary>
        public string Users_SessionKey { get; set; }
        /// <summary>
        /// 用户OpenID
        /// </summary>
        public string Users_OpenID { get; set; }
        /// <summary>
        /// 微信接口获取的session_key
        /// </summary>
        public string session_key { get; set; }
        /// <summary>
        /// 微信接口获取的openid
        /// </summary>
        public string openid { get; set; }

    }
    
}
