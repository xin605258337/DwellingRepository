 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    public class WxImage
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public int WxImage_ID { get; set; }
        /// <summary>
        /// 所属房源ID 
        /// </summary>
        public int WxHouse_ID { get; set; }
        /// <summary>
        /// 图片url
        /// </summary>
        public string WxImage_Url { get; set; }
    }
}
