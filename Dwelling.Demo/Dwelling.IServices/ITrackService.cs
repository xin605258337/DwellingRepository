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
        /// <summary>
        /// 根据用户获得用户足迹
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Track> GetTracksByUserId(int userId);
    }
}
