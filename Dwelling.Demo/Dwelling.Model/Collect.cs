﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //收藏表
  public  class Collect:HouseDetails
    {
        /// <summary>
        /// 收藏ID
        /// </summary>
        public int Collect_ID { get; set; }
        /// <summary>
        /// 所属用户
        /// </summary>
        public int Users_ID { get; set; }

    }
}
