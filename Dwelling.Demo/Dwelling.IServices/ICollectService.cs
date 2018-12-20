using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //收藏接口
    public interface ICollectService
    {
        /// <summary>
        /// 添加收藏表
        /// </summary>
        /// <param name="_House_ID"></param>
        /// <returns></returns>
        int AddCollect(Collect collect);
        /// <summary>
        /// 根据用户ID获取用户收藏
        /// </summary>
        /// <returns></returns>
        List<Collect> GetCollects(int userId);

        House GetHouseByName(string _House_Name);

        List<House> GetHousesByCollect();
    }
}
