﻿using System;
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
    public class HouseApiController : ApiController
    {
        [Dependency]
        public IHouseService HouseService { get; set; }
        [Dependency]
        public IBuildingTypeService BuildingTypeService { get; set; }

        [Dependency]
        public IStyleService StyleService { get; set; }
        [Dependency]
        public IOrientationService OrientationService { get; set; }
        [Dependency]
        public ILeaseTypeService LeaseTypeService { get; set; }
        [Dependency]
        public IHabitableroomServices HabitableroomServices { get; set; }
        [Dependency]
        public IFacilityService FacilityServices { get; set; }
        [Dependency]
        public IPriceService PriceServices { get; set; }
        [Dependency]
        public IAreaService AreaServices { get; set; }
        /// <summary>
        /// 根据添加房源的第一张图片url获得房源ID
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHouseIdByImgUrl")]
        public int GetHouseIdByImgUrl(string imgUrl)
        {
            return HouseService.GetHouseIdByImgUrl(imgUrl);
        }
        /// <summary>
        /// 添加房源
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddHouse")]
        public int AddHouse(House house)
        {
            return HouseService.AddHouse(house);
        }
        /// <summary>
        /// 根据ID删除房源信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteHouse")]
        public int DeleteHouse(int houseId)
        {
            return HouseService.DeleteHouse(houseId);
        }
        /// <summary>
        /// 根据房源ID获取房源信息
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHouseByID")]
        public HouseDetails GetHouseByID(int houseId)
        {
            return HouseService.GetHouseByID(houseId);
        }
        /// <summary>
        /// 获取热门房源排序
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHotHouses")]
        public List<HouseDetails> GetHotHouses()
        {
            return HouseService.GetHotHouses();
        }
        /// <summary>
        /// 获取所有房源信息
        /// </summary>
        /// <param name="buildingTypeId">房源类型ID（电梯，楼梯）</param>
        /// <param name="habitableRoomId">户型ID</param>
        /// <param name="leaseTypeId">出租类型ID</param>
        /// <param name="Orientation">朝向ID</param>
        /// <param name="styleId">装修风格ID</param>
        /// <returns></returns>
        [HttpGet]   
        [Route("GetHouses")]
        public List<HouseDetails> GetHouses(string houseName="", string regionId = "", int buildingTypeId=0,int habitableRoomId=0,int leaseTypeId=0,int Orientation=0,int styleId=0)
        {
            List<HouseDetails> houseDetailsList = HouseService.GetHouses(houseName, regionId,buildingTypeId, habitableRoomId, leaseTypeId, Orientation, styleId);
            return houseDetailsList; 
        }
        /// <summary>
        /// 修改房源点击数
        /// </summary>
        /// <param name="clickNum"></param>
        /// <param name="houseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UpdateHouseClickNum")]
        public int UpdateHouseClickNum(int clickNum, int houseId)
        {
            return HouseService.UpdateHouseClickNum(clickNum, houseId);
        }
        /// <summary>
        /// 根据出租类型获取房源
        /// </summary>
        /// <param name="leaseTypeName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHouseByLeaseType")]
        public List<HouseDetails> GetHouseByLeaseType(string leaseTypeName)
        {
            return HouseService.GetHouseByLeaseType(leaseTypeName);
        }
        /// <summary>
        /// 获取房源类型信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBuildingType")]
        public List<BuildingType> GetBuildingType()
        {
            return BuildingTypeService.GetBuildingType();
        }
        [HttpGet]
        [Route("GetHabitableRoom")]
        /// <summary>
        /// 获取户型信息
        /// </summary>
        /// <returns></returns>
        public List<HabitableRoom> GetHabitableRoom()
        {
            return HabitableroomServices.GetHabitableRoom();
        }
        [HttpGet]
        [Route("GetLeaseType")]
        /// <summary>
        /// 获取出租类型信息
        /// </summary>
        /// <returns></returns>
        public List<LeaseType> GetLeaseType()
        {
            return LeaseTypeService.GetLeaseType();
        }
        [HttpGet]
        [Route("GetOrientation")]
        /// <summary>
        /// 获取房源朝向信息
        /// </summary>
        /// <returns></returns>
        public List<Orientation> GetOrientation()
        {
            return OrientationService.GetOrientation();
        }
        [HttpGet]
        [Route("GetStyle")]
        /// <summary>
        /// 获取房源风格信息
        /// </summary>
        /// <returns></returns>
        public List<Style> GetStyle()
        {
            return StyleService.GetStyle();
        }
        [HttpGet]
        [Route("GetFacility")]
        /// <summary>
        /// 获取房源设施信息
        /// </summary>
        /// <returns></returns>
        public List<Facility> GetFacility()
        {
            return FacilityServices.GetFacility();
        }
        [HttpGet]
        [Route("GetPrice")]
        /// <summary>
        /// 获取价格范围信息
        /// </summary>
        /// <returns></returns>
        public List<Price> GetPrice()
        {
            return PriceServices.GetPrice();
        }

        [HttpGet]
        [Route("GetArea")]
        /// <summary>
        /// 获取面积范围信息
        /// </summary>
        /// <returns></returns>
        public List<Area> GetArea()
        {
            return AreaServices.GetArea();
        }

        /// <summary>
        /// 根据区分组查询点击量
        /// </summary>
        /// <returns></returns>
        [Route("GetECharts")]
        [HttpGet]
        public List<House> GetECharts()
        {
            return HouseService.GetECharts();
        }
        /// <summary>
        /// 根据启用按钮发布房源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="House_IsEnable"></param>
        /// <returns></returns>
        [Route("updateHouseIsEnable")]
        [HttpGet]
        public int updateHouseIsEnable(int id, int House_IsEnable)
        {
            return HouseService.updateHouseIsEnable(id,House_IsEnable);
        }
        /// <summary>
        /// 获取所有房源信息
        /// </summary>
        /// <param name="buildingTypeId">房源类型ID（电梯，楼梯）</param>
        /// <param name="habitableRoomId">户型ID</param>
        /// <param name="leaseTypeId">出租类型ID</param>
        /// <param name="Orientation">朝向ID</param>
        /// <param name="styleId">装修风格ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHotHousesbyenable")]
        public List<HouseDetails> GetHotHousesbyenable(string houseName = "", string regionId = "", int buildingTypeId = 0, int habitableRoomId = 0, int leaseTypeId = 0, int Orientation = 0, int styleId = 0)
        {
            List<HouseDetails> houseDetailsList = HouseService.GetHotHousesbyenable(houseName, regionId, buildingTypeId, habitableRoomId, leaseTypeId, Orientation, styleId);
            return houseDetailsList;
        }

    }
}
