﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //投诉表
   public class Complain:Users
    {
        /// <summary>
        /// 投诉表ID
        /// </summary>
        public int Complain_ID { get; set; }
        /// <summary>
        /// 投诉内容
        /// </summary>
        public string Complain_Content { get; set; }
        /// <summary>
        /// 投诉结果
        /// </summary>
        public string Complain_Result { get; set; }
        /// <summary>
        /// 投诉所属用户
        /// </summary>
        public new int Users_ID { get; set; }
    }
}
