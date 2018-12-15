using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
  public class Permission
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public int Permission_ID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Permission_Name { get; set; }

        /// <summary>
        /// 权限路径
        /// </summary>
        public string Permission_Url { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>

        public string Permission_Enabel { get; set; }
        /// <summary>
        ///备注
        /// </summary>

        public string Permission_Remark { get; set; }
    }
}
