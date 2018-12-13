using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //图片表接口
    public interface IImageService
    {
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <returns></returns>
       int AddImg(int houseId, string imgUrl);
    }
}
