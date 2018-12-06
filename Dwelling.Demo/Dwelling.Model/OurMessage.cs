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
        public int Version { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public int ProjectName { get; set; }
        /// <summary>
        /// 官方网站
        /// </summary>
        public int OfficialWebsite { get; set; }
        /// <summary>
        /// 客服电话
        /// </summary>
        public int ServiceTel { get; set; }
  
    }
}
