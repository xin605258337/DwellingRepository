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
        int AddCollect(int _House_ID);

        House GetHouseByName(string _House_Name);

        List<House> GetHousesByCollect();
    }
}
