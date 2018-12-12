using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //管理员表
    public class Admin
    {
        /// <summary>
        ///管理员ID 
        /// </summary>
        public int Admin_ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Admin_Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Admin_Password { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string Admin_Permission { get; set; }

        public int Admin_number { get; set; }
        public string Admin_remark { get; set; }
        public string Admin_email { get; set; }
        public string Admin_sex { get; set; }
    }
}
