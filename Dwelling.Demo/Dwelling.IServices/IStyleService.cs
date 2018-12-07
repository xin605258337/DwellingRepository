using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //风格接口
    public interface IStyleService
    {
        /// <summary>
        /// 房源风格
        /// </summary>
        /// <returns></returns>
        List<Style> GetStyle();
    }
}
