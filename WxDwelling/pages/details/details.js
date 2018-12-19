Page({
  data: {
    conferencelist: [],
    spaceimgs: [],
    currentIndex: 1,
    url:[]
  },
  onLoad: function (options) {
    this.setData({
      houseID: options.ID
    })
    const newlist = [];
    var that = this;
    //获得房源所有图片
    wx.request({
      url: 'http://localhost:8092/Dwelling/GetImageByHouseId',
      method: 'GET',
      data: {
        houseId: options.ID
      },
      success: function (res) {
        
        that.setData({
          url: res.data
        })
        wx.request({
          url: 'http://localhost:8092/Dwelling/GetHouseByID?houseId=' + options.ID,
          method: 'GET',
          header: {
            'content-type': 'application/json'
          },
          success: function (res) {
            console.log(res.data)
            newlist.push({
              "HousePrice": res.data.House_RentMoney,//价格
              "Renovation": res.data.Style_Name,//装饰情况
              "HouseBuilt_upArea": res.data.House_Area,//房屋面积
              //"ResidRegion": res.data.,//地理位置
              "TypeName": res.data.BuildingType_Name,//房源类型
              "ResidName": res.data.House_Address,//房源名称
              "IndoorUrl": that.data.url, //"http://localhost:55909/Content/Img/" + res.data.House_ImgUrl,//图片显示
              "DetaTitle": res.data.House_Name,//房源标题
              "DetaDescribe": res.data.House_Describe,//描述
              "DetaIntroduce": res.data.House_Facility,//广告
              //"DetaMentality": res.data.DetaMentality,//广告
              "HouseApartmentlayout": res.data.HabitableRoom_Name,//几室几厅
              "HouseCreateTime": res.data.LeaseType_Name,//出租类型
              "House_OwnerTel": res.data.House_OwnerTel,//所属人电话
              "House_OwnerWx": res.data.House_OwnerWx,//所属人微信
            })
            that.setData({
              conferencelist: newlist
            })
            //修改点击数
            wx.request({
              url: 'http://localhost:8092/Dwelling/UpdateHouseClickNum',
              method: 'GET',
              data: {
                clickNum: res.data.House_ClickNum,
                houseId: options.ID
              },
              success: function (res) {
                console.log(res.data)
                wx.getStorage({
                  key: 'userId',
                  success: function(res) {
                    //加入足迹
                    wx.request({
                      url: 'http://localhost:8092/Dwelling/AddTrack',
                      method: 'GET',
                      data: {
                        houseId: options.ID,
                        userId:res.data
                      },
                      success:function(reg){
                        if(res.data>0)
                        {
                          console.log('添加足迹成功')
                        }
                      }
                    })
                  },
                })
              }
            })
          }
        })
      }
    })
    
  },
  //添加收藏
  AddCollect:function(){
    wx.getStorage({
      key: 'userId',
      success: function (res) {
        wx.request({
          url: 'http://localhost:8092/Dwelling/AddCollect',
          method: 'GET',
          data: {
            houseId: houseID,
            userId: res.data
          },
          success: function (reg) {
            if (res.data > 0) {
              console.log('添加收藏成功')
            }
          }
        })
      },
    })

  }
  })

