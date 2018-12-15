using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
   public class RolePermission
    {
        /// <summary>
        /// 权限角色关联表
        /// </summary>
        public int RolePermission_ID { get; set; }
        /// <summary>
        /// 权限id关联
        /// </summary>
        public int Permission_ID { get; set; }
        /// <summary>
        /// 角色id关联
        /// </summary>
        public int Role_ID { get; set; }
    }
}
