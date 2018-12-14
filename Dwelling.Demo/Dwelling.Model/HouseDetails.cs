using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    public class HouseDetails:House
    {
        /// <summary>
        /// 面积范围
        /// </summary>
        public string Area_Name { get; set; }
        /// <summary>
        /// 房源类型
        /// </summary>
        public string BuildingType_Name { get; set; }
        /// <summary>
        /// 户型
        /// </summary>
        public string HabitableRoom_Name { get; set; }
        /// <summary>
        /// 出租类型
        /// </summary>
        public string LeaseType_Name { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>
        public string Orientation_Name { get; set; }
        /// <summary>
        /// 房源风格
        /// </summary>
        public string Style_Name { get; set; }
    }
}
