using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dwelling.Api.Controllers
{
    using Unity;
    using Unity.Attributes;
    using Dwelling.IServices;
    using Dwelling.Model;
    using Dwelling.Common;
    [RoutePrefix("Dwelling")]
    public class TrackController : ApiController
    {
        [Dependency]
        public ITrackService TrackService { get; set; }
        /// <summary>
        /// 添加足迹
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AddTrack")]
        public int AddTrack(int houseId, int userId)
        {
            Track track = new Track();
            track.House_ID = houseId;
            track.Users_ID = userId;
            return TrackService.AddTrack(track);
        }
        /// <summary>
        /// 根据用户获得用户足迹
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTracksByUserId")]
        public List<Track> GetTracksByUserId(int userId)
        {
            return TrackService.GetTracksByUserId(userId);
        }
    }
}
