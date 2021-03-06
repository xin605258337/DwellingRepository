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
        /// <summary>
        /// 根据出租类型获取房源
        /// </summary>
        /// <param name="leaseTypeName"></param>
        /// <returns></returns>
        List<HouseDetails> GetHouseByLeaseType(string leaseTypeName);

        /// <summary>
        /// 根据区分组查询点击量
        /// </summary>
        /// <returns></returns>
        List<House> GetECharts();
        /// <summary>
        /// 修改发布房源启用按钮
        /// </summary>
        /// <param name="id"></param>
        /// <param name="House_IsEnable"></param>
        /// <returns></returns>
        int updateHouseIsEnable(int id, int House_IsEnable);


        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        List<HouseDetails> GetHotHousesbyenable(string houseName = "", string regionId = "", int buildingTypeId = 0, int habitableRoomId = 0, int leaseTypeId = 0, int Orientation = 0, int styleId = 0);
    }
}
