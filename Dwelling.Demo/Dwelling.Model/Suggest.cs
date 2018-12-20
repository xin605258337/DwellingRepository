using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //建议表
     public class Suggest:Users
    {
        /// <summary>
        /// 建议ID
        /// </summary>
        public int Suggest_ID { get; set; }
     
        /// <summary>
        /// 建议内容
        /// </summary>
        public string Suggest_Content { get; set; }
        /// <summary>
        /// 建议图片
        /// </summary>
        public string Suggest_Result { get; set; }
        /// <summary>
        /// 建议所属用户
        /// </summary>
        public new int Users_ID { get; set; }
    }
}
