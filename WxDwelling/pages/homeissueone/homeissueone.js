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
    arr: []
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
        url: 'http://localhost:8092/Dwelling/AddPublishHouse',
        method: 'post',
        data: {
          PublishHouse_Owner: that.data.owner,
          PublishHouse_OwnerTel: that.data.tel,
          PublishHouse_RentMoney: that.data.price,
          HabitableRoom_ID: that.data.roomTypeId,
          PublishHouse_Description: that.data.description,
          PublishHouse_Num: that.data.PublishHouse_Num,
          PublishHouse_Area: that.data.PublishHouse_Area,
          Orientation_ID: that.data.Orientation[that.data.hx_index_1].Orientation_ID,
          BuildingType_ID: that.data.BuildingType[that.data.hx_index_2].BuildingType_ID,
          Style_ID: that.data.Style[that.data.hx_index_3].Style_ID,
          PublishHouse_Floor: that.data.PublishHouse_Floor,
          PublishHouse_SumFloor: that.data.PublishHouse_SumFloor,
          PublishHouse_Payment: that.data.PublishHouse_Payment,
          PublishHouse_RentTimeBegin: that.data.PublishHouse_RentTimeBegin,
          PublishHouse_RentTimeEnd: that.data.PublishHouse_RentTimeEnd,
          PublishHouse_Facility: that.data.PublishHouse_Facility,
          PublishHouse_ImgUrl: that.data.arr[0]


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
      url: 'http://localhost:8092/Dwelling/AddPublishHouse',
      method: 'post',
      data: {
        PublishHouse_Owner: that.data.owner,
        PublishHouse_OwnerTel: that.data.tel,
        PublishHouse_RentMoney: that.data.price,
        HabitableRoom_ID: that.data.roomTypeId,
        PublishHouse_Description: that.data.description,
        PublishHouse_RentMoney: this.data.PublishHouse_RentMoney,
        PublishHouse_Area: this.data.PublishHouse_Area,
        BuildingType_ID: this.data.BuildingType[this.data.hx_index_2].BuildingType_ID,
        PublishHouse_Floor: this.data.PublishHouse_Floor,
        PublishHouse_SumFloor: this.data.PublishHouse_SumFloor,
        PublishHouse_RentTimeBegin: this.data.PublishHouse_RentTimeBegin,


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