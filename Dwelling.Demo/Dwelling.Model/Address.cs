﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //地址表
  public  class Address
    {
        /// <summary>
        /// 地址ID
        /// </summary>
        public int Address_ID { get; set; }
        /// <summary>
        /// 地址名
        /// </summary>
        public string Address_Name { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int Address_pID { get; set; }
    }
}
