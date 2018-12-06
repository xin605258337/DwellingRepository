using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Model
{
    //朝向表
  public  class Orientation
    {
        /// <summary>
        /// 朝向ID
        /// </summary>
        public int Orientation_ID { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>
        public string Orientation_Name { get; set; }
    }
}
