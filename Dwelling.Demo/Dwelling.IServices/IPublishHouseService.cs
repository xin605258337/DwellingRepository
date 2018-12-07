using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    public  interface IPublishHouseService
    {
        /// <summary>
        /// 添加房源
        /// </summary>
        /// <param name="House"></param>
        /// <returns></returns>
        int AddPublishHouse(PublishHouse House);
        /// <summary>
        /// 显示房源  补缺模糊查询参数
        /// </summary>
        /// <returns></returns>
        List<PublishHouse> GetPublishHouse();
        /// <summary>
        /// 删除房源信息
        /// </summary>
        /// <param name="PublishHouseID"></param>
        /// <returns></returns>

        int deletePublishHouse(int PublishHouseID);
    }
}
