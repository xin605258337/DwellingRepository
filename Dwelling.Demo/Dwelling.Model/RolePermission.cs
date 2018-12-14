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
        public int Rolepermission_ID { get; set; }
        /// <summary>
        /// 权限id关联
        /// </summary>
        public int permission_ID { get; set; }
        /// <summary>
        /// 角色id关联
        /// </summary>
        public int role_ID { get; set; }
    }
}
