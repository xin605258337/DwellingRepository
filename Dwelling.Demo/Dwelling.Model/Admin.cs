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
        /// 性别
        /// </summary>
        public int Admin_Gender { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Admin_Tel { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Admin_Email { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public int Role_ID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Admin_Remark { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Role_Name { get; set; }
        /// <summary>
        /// 权限路径
        /// </summary>
        public string Permission_Url { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Permission_Name { get; set; }

    }
}
