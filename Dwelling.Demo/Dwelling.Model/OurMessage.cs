using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //项目信息表（关于我们）
   public  class OurMessage
    {
        public int Id { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string  Version { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string  ProjectName { get; set; }
        /// <summary>
        /// 官方网站
        /// </summary>
        public string  OfficialWebsite { get; set; }
        /// <summary>
        /// 客服电话
        /// </summary>
        public string  ServiceTel { get; set; }
  
    }
}
