using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //房源朝向接口
    public interface IOrientationService
    {
        /// <summary>
        /// 房源朝向
        /// </summary>
        /// <returns></returns>
        List<Orientation> GetOrientation();
    }
}
