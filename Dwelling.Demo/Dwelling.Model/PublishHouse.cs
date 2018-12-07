using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //发布房源表
    public class PublishHouse
    {
        /// <summary>
        /// ID
        /// </summary>
        public int PublishHouse_ID { get; set; }
        /// <summary>
        /// 户型id
        /// </summary>
        public int HabitableRoom_ID { get; set; }
        /// <summary>
        /// 房间号
        /// </summary>
        public string  PublishHouse_Num { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public double PublishHouse_Area { get; set; }
        /// <summary>
        /// 朝向id
        /// </summary>
        public int Orientation_ID { get; set; }
        /// <summary>
        /// 租金
        /// </summary>
        public decimal PublishHouse_RentMoney { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        public int PublishHouse_Floor { get; set; }
        /// <summary>
        /// 总楼层
        /// </summary>
        public int PublishHouse_SumFloor { get; set; }
        /// <summary>
        /// 楼房类型id
        /// </summary>
        public int BuildingType_ID { get; set; }
        /// <summary>
        /// 起租开始日期
        /// </summary>
        public DateTime PublishHouse_RentTimeBegin { get; set; }
        /// <summary>
        /// 起租结束日期
        /// </summary>
        public DateTime PublishHouse_RentTimeEnd { get; set; }
        /// <summary>
        /// 房源图片
        /// </summary>
        public string PublishHouse_ImgUrl { get; set; }
        /// <summary>
        /// 房源描述
        /// </summary>
        public string  PublishHouse_Description { get; set; }
        /// <summary>
        /// 房源设施
        /// </summary>
        public string  PublishHouse_Facility { get; set; }
        /// <summary>
        /// 出租类型id
        /// </summary>
        public int LeaseType_ID { get; set; }
        /// <summary>
        /// 风格id
        /// </summary>
        public int Style_ID { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string  PublishHouse__Payment { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        public string ApprovalStatic { get; set; }


    }
}
