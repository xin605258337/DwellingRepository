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
        /// <summary>
        /// 根据房源ID获取房源所有图片
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        List<Image> GetImageByHouseId(int houseId);
    }
}
