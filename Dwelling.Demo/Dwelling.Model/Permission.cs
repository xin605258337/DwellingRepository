using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
  public  class Permission
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public int permission_ID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string permission_Name { get; set; }
        /// <summary>
        /// 权限路径
        /// </summary>
        public string permission_Url { get; set; }


        /// <summary>
        /// 用于递归自联id
        /// </summary>
        public int Pid { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string enable { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int rank { get; set; }

    }
}
