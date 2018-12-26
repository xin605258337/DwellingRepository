// pages/homeissueone/homeissueone.js
import {
  promisify
} from '../../utils/promise.util'
import {
  $init,
  $digest
} from '../../utils/common.util'

const wxUploadFile = promisify(wx.uploadFile)
Page({

  /**
   * 页面的初始数据
   */
  data: {
    /**默认合租页面 */
    current: 1,
    Orientation: [],
    BuildingType: [],
    Style: [],
    hx_index_1: 0,
    hx_index_2: 0,
    hx_index_3: 0,
    Facilityitems: [],
    images: [],
    arr: [],
    multiIndex: [0, 0],
    multiArray: [
      [
        "不限"
      ],
      ["不限"]
    ],
    objectMultiArray: [
      [{
        "id": 0,
        "title": "不限"
      }],
      [{
        "id": 0,
        "title": "不限"
      }]
    ]
  },

  //图片上传
  chooseImage(e) {
    wx.chooseImage({
      count: 9,
      sizeType: ['original', 'compressed'],
      sourceType: ['album', 'camera'],
      success: res => {
        const images = this.data.images.concat(res.tempFilePaths)
        this.data.images = images.length <= 9 ? images : images.slice(0, 9)
        $digest(this)
      }
    })
  },
  removeImage(e) {
    const idx = e.target.dataset.idx
    this.data.images.splice(idx, 1)
    $digest(this)
  },

  submitForm(e) {
    const arr = [];
    for (let path of this.data.images) {
      wxUploadFile({
        url: 'http://localhost:55909/House/GetImgByWx',
        filePath: path,
        name: 'qimg',
      })
    }
    wx.showLoading({
      title: '正在创建...',
      mask: true
    })

  },

  //下拉选框绑定
  bindPickerChange_hx: function(e) {
    // console.log('picker发送选择改变，携带值为', e.detail.value);
    this.setData({ //给变量赋值
      hx_index: e.detail.value, //每次选择了下拉列表的内容同时修改下标然后修改显示的内容，显示的内容和选择的内容一致
    })
  },
  bindPickerChange_hx_1: function(e) {
    // console.log('picker发送选择改变，携带值为', e.detail.value);
    this.setData({ //给变量赋值
      hx_index_1: e.detail.value, //每次选择了下拉列表的内容同时修改下标然后修改显示的内容，显示的内容和选择的内容一致
    })
  },
  bindPickerChange_hx_2: function(e) {
    // console.log('picker发送选择改变，携带值为', e.detail.value);
    this.setData({ //给变量赋值
      hx_index_2: e.detail.value, //每次选择了下拉列表的内容同时修改下标然后修改显示的内容，显示的内容和选择的内容一致
    })
  },
  bindPickerChange_hx_3: function(e) {
    // console.log('picker发送选择改变，携带值为', e.detail.value);
    this.setData({ //给变量赋值
      hx_index_3: e.detail.value, //每次选择了下拉列表的内容同时修改下标然后修改显示的内容，显示的内容和选择的内容一致
    })
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    $init(this)
    this.setData({
      owner: options.owner,
      tel: options.tel,
      price: options.price,
      roomTypeId: options.roomTypeId,
      description: options.description,
    })
    console.log(options.owner)
    console.log(options.tel)
    console.log(options.price)

    var that = this;
    wx.request({
      url: 'https://apis.map.qq.com/ws/district/v1/getchildren?id=110000&key=HYPBZ-PNF3J-GRYFR-K4XZ2-3YXLV-67B5R',
      method: 'GET',
      success: function (res) {
        for (var i = 0; i < res.data.result[0].length; i++) {
          that.data.multiArray[0].push(res.data.result[0][i].fullname)
          that.data.objectMultiArray[0].push({
            "id": res.data.result[0][i].id,
            "title": res.data.result[0][i].fullname
          })
        }
        that.setData({
          multiArray: that.data.multiArray,
          objectMultiArray: that.data.objectMultiArray
        })
        console.log(that.data.multiArray)
      }
    })
    //获取朝向
    wx.request({
      url: 'http://localhost:8092/Dwelling/GetOrientation',
      success: function(res) {
        that.setData({
          Orientation: res.data //把json数据赋值给变量Orientation
        })
        //获取楼房类型
        wx.request({
          url: 'http://localhost:8092/Dwelling/GetBuildingType',
          success: function(res) {
            that.setData({
              BuildingType: res.data //把json数据赋值给变量BuildingType
            })
            //获取装修风格
            wx.request({
              url: 'http://localhost:8092/Dwelling/GetStyle',
              success: function(res) {
                that.setData({
                  Style: res.data //把json数据赋值给变量Style
                })
                //获取房屋设施
                wx.request({
                  url: 'http://localhost:8092/Dwelling/GetFacility',
                  success: function(res) {
                    that.setData({
                      Facilityitems: res.data //把json数据赋值给变量Facilityitems
                    })
                  }
                })
              }
            })
          }
        })
      }
    })
  },
  bindMultiPickerChange: function (e) {
    this.setData({
      "multiIndex[0]": e.detail.value[0],
      "multiIndex[1]": e.detail.value[1],
    })
  },
  bindMultiPickerColumnChange: function (e) {
    var that = this;
    var list = ['不限'];
    var objectList = [{
      "id": 0,
      "title": "不限"
    }];
    if (e.detail.column == 0) {
      wx.request({
        url: 'https://apis.map.qq.com/ws/district/v1/getchildren?id=' + that.data.objectMultiArray[0][e.detail.value].id + '&key=HYPBZ-PNF3J-GRYFR-K4XZ2-3YXLV-67B5R',
        method: 'GET',
        success: function (res) {
          for (var i = 0; i < res.data.result[0].length; i++) {
            list.push(
              res.data.result[0][i].fullname
            )
            objectList.push({
              "id": res.data.result[0][i].id,
              "title": res.data.result[0][i].fullname
            })
          }
          that.data.multiArray[1] = list
          that.data.objectMultiArray[1] = objectList;
          that.setData({
            multiArray: that.data.multiArray,
            objectMultiArray: that.data.objectMultiArray
          })
        }
      })
    }
  },

  //出租房间
  inputPhone: function(e) {
    this.setData({
      PublishHouse_Num: e.detail.value,

    })
  },
  ///面积
  inputArea: function(e) {
    this.setData({

      PublishHouse_Area: e.detail.value
    })

  },
  //楼层
  inputFloor: function(e) {
    this.setData({
      PublishHouse_Floor: e.detail.value

    })

  },
  //总楼层
  inputSumFloor: function(e) {
    this.setData({

      PublishHouse_SumFloor: e.detail.value
    })


  },
  inputHouse_Address:function(e)
  {
    this.setData({
      House_Address:e.detail.value

    })   
  },
  ///付款方式
  inputPayment: function(e) {
    this.setData({

      PublishHouse_Payment: e.detail.value
    })


  },
  //起止日期
  inputRentTimeBegin: function(e) {
    this.setData({

      PublishHouse_RentTimeBegin: e.detail.value
    })


  },
  inputHouse_Name:function(e)
  {
this.setData({
  House_Name:e.detail.value
})
  }
  ,
  inputRentMoney: function(e) {
    this.setData({

      PublishHouse_RentMoney: e.detail.value
    })

  },
  ///止租日期

  inputRentTimeEnd: function(e) {
    this.setData({

      PublishHouse_RentTimeEnd: e.detail.value
    })
  },
  ///复选框绑定
  checkboxChange: function(e) {
    // console.log('picker发送选择改变，携带值为', e.detail.value);
    this.setData({ //给变量赋值
      PublishHouse_Facility: e.detail.value.join(','), //每次选择了下拉列表的内容同时修改下标然后修改显示的内容，显示的内容和选择的内容一致
    })
    console.log('picker发送选择改变，携带值为', this.data.PublishHouse_Facility)
  },
  //发布房源信息
  onSubmit: function(e) {
    const arr = []
    var that = this;
    for (var i = 0; i < this.data.images.length; i++) {

      arr.push(wxUploadFile({
        url: 'http://localhost:55909/House/GetImgByWx',
        filePath: this.data.images[i],
        name: 'qimg',
      }))
    }
    Promise.all(arr).then(function(res) {
      for (var i = 0; i < res.length; i++) {
        that.data.arr = that.data.arr.concat(JSON.parse(res[i].data))
      }
      console.log(that.data.arr)
      wx.request({
        url: 'http://localhost:8092/Dwelling/AddHouse',
        method: 'post',
        data: {
          House_Owner: that.data.owner,
          House_OwnerTel: that.data.tel,
          House_RentMoney: that.data.price,
          HabitableRoom_ID: that.data.roomTypeId,
          House_Describe: that.data.description,
          House_Num: that.data.PublishHouse_Num,
          House_Area: that.data.PublishHouse_Area,
          Orientation_ID: that.data.Orientation[that.data.hx_index_1].Orientation_ID,
          BuildingType_ID: that.data.BuildingType[that.data.hx_index_2].BuildingType_ID,
          Style_ID: that.data.Style[that.data.hx_index_3].Style_ID,
          House_Floor   : that.data.PublishHouse_Floor,
          House_SumFloor: that.data.PublishHouse_SumFloor,
          House_Payment: that.data.PublishHouse_Payment,
          House_RentTimeBegin: that.data.PublishHouse_RentTimeBegin,
          House_RentTimeEnd: that.data.PublishHouse_RentTimeEnd,
          House_Facility: that.data.PublishHouse_Facility,
          House_ImgUrl: that.data.arr[0],
          Region_ID: that.data.objectMultiArray[0][that.data.multiIndex[0]].id,
          Street_ID: that.data.objectMultiArray[1][that.data.multiIndex[1]].id,
          House_Address: that.data.House_Address,
          House_IsEnable:0,  
          House_Name: that.data.House_Name  ,
          LeaseType_ID:1

                


        },
        success: function(res) {
          if (res.data > 0) {
            wx.showToast({
              title: '添加成功',
              duration: 2000 //提示两秒钟后关闭标题
            })
          }
        }
      })
    })



  },

  ///整租
  onSubmit1: function(e) {
    var that = this;
    wx.request({
      url: 'http://localhost:8092/Dwelling/AddHouse',
      method: 'post',
      data: {
        House_Owner: that.data.owner,
        House_OwnerTel: that.data.tel,
        House_RentMoney: that.data.price,
        HabitableRoom_ID: that.data.roomTypeId,
        House_Describe: that.data.description,
        House_Price: this.data.PublishHouse_RentMoney,
        House_Area: this.data.PublishHouse_Area,
        BuildingType_ID: this.data.BuildingType[this.data.hx_index_2].BuildingType_ID,
        House_Floor: this.data.PublishHouse_Floor,
        House_SumFloor: this.data.PublishHouse_SumFloor,
        House_RentTimeBegin: this.data.PublishHouse_RentTimeBegin,
        Region_ID: that.data.objectMultiArray[0][that.data.multiIndex[0]].id,
        Street_ID: that.data.objectMultiArray[1][that.data.multiIndex[1]].id,
        LeaseType_ID: 2
       
        

      },
      success: function(res) {
        if (res.data > 0) {

          wx.showToast({
            title: '添加成功',
            duration: 2000 //提示两秒钟后关闭标题
          })
        }
      }



    })


  },
  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function() {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function() {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function() {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function() {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function() {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function() {

  },

  /** */
  swiperTab: function(e) {
    var that = this;
    that.setData({
      current: e.detail.current
    });
  },
  /**点击事件 */
  clickTab: function(e) {
    var that = this;
    if (this.data.current === e.target.dataset.current) {
      return false;
    } else {
      that.setData({
        current: e.target.dataset.current
      })
    }
  },

  /**改变合租整租跳转页面 */

  swiperChange: function(e) {
    this.setData({
      swiperCurrent: e.detail.current
    });
  },
})