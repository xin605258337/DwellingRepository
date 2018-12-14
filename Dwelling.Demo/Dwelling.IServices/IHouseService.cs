﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //房源接口
    public interface IHouseService
    {
        /// <summary>
        /// 添加房源
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        int AddHouse(House house);

        /// <summary>
        /// 根据ID删除房源信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteHouse(int houseId);
        /// <summary>
        /// 根据房源ID获取房源信息
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        HouseDetails GetHouseByID(int houseId);
        /// <summary>
        /// 获取所有房源信息
        /// </summary>
        /// <returns></returns>
        List<HouseDetails> GetHouses(string houseName = "", string regionId = "", int buildingTypeId = 0, int habitableRoomId = 0, int leaseTypeId = 0, int Orientation = 0, int styleId = 0);
        /// <summary>
        /// 根据添加房源的第一张图片url获得房源ID
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        int GetHouseIdByImgUrl(string imgUrl);
        /// <summary>
        /// 获取热门房源排序
        /// </summary>
        /// <returns></returns>
        List<HouseDetails> GetHotHouses();
        /// <summary>
        /// 修改房源点击数
        /// </summary>
        /// <param name="clickNum"></param>
        /// <param name="houseId"></param>
        /// <returns></returns>
        int UpdateHouseClickNum(int clickNum, int houseId);
    }
}
