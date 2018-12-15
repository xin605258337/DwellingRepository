using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    /// <summary>
    /// 管理员角色关联表
    /// </summary>
    public class AdminRole
    {
        /// <summary>
        /// ID
        /// </summary>
        public int AdminRole_ID { get; set; }
        /// <summary>
        ///管理员ID 
        /// </summary>
        public int Admin_ID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int Role_ID { get; set; }
    }
}
