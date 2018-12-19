using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //足迹接口
    public interface ITrackService
    {
        /// <summary>
        /// 添加足迹
        /// </summary>
        /// <returns></returns>
        int AddTrack(Track track);
    }
}
