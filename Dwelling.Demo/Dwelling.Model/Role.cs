using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    public class Role
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int role_ID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string role_Name { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string permission_Name { get; set; }
    }
}
