using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Common
{
    using Dwelling.Model;
    using System.Net.Http;
    using Dapper;
    using MySql.Data;
    using MySql.Data.MySqlClient;
    using Newtonsoft.Json;
    using System.Data;
    using System.Configuration;

    public class Token
    {
        //连接数据库字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
        MySqlConnection conn = null;
        public Token()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        }
        /// <summary>
        /// 获取微信会话密钥
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Users Logins(string code)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            List<Users> usersList = conn.Query<Users>("pro_GetUsers", null, commandType: CommandType.StoredProcedure).ToList();
            Users user = new Users();
            HttpClient httpclient = new HttpClient();
            //登陆公众平台 开发->基本配置中的开发者ID(AppID)和 开发者密码(AppSecret)
            string appid = "wxe47e27cfa22da27f";//开发者ID
            string secret = "66ab3ae38fa57b2736632079b789a416";//开发者秘钥
            httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpclient.PostAsync("https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + secret + "&js_code=" + code.ToString() + "&grant_type=authorization_code", null).Result;
            var result = "";
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            httpclient.Dispose();
            var results = JsonConvert.DeserializeObject<Users>(result);
            user.Users_OpenID = results.openid;//用户唯一标识
            user.Users_SessionKey = results.session_key;//密钥
            var u = usersList.Where(n => n.Users_OpenID.Equals(user.Users_OpenID)).FirstOrDefault();//判断是否为已注册用户
            if (u == null)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_Users_OpenID", user.Users_OpenID);
                parameters.Add("_Users_SessionKey", user.Users_SessionKey);
                conn.Execute("pro_AddUsers", parameters, commandType: CommandType.StoredProcedure);
                u= conn.Query<Users>("pro_GetUsers", null, commandType: CommandType.StoredProcedure).Where(n => n.Users_OpenID.Equals(user.Users_OpenID)).FirstOrDefault();
            }
            user.Users_ID = u.Users_ID;
            RedisHelper.Set<Users>(user.Users_SessionKey, user, DateTime.Now.AddHours(10));
            return user;
        }
    }
}
