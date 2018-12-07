using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //房源图片表
    public class Image
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public int Image_ID { get; set; }
        /// <summary>
        /// 所属房源ID 
        /// </summary>
        public int House_ID { get; set; }
        /// <summary>
        /// 图片url
        /// </summary>
        public string Image_Url { get; set; }
    }
}
