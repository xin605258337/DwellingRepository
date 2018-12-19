// pages/homeissueone/homeissueone.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    /**默认合租页面 */
    currentTab: 0,
    Orientation: [],
    BuildingType:[],
    Style:[],
    hx_index: 0,
    Facilityitems:[],
  },
  //下拉选框绑定
  bindPickerChange_hx: function (e) {
    // console.log('picker发送选择改变，携带值为', e.detail.value);
    this.setData({   //给变量赋值
      hx_index: e.detail.value,  //每次选择了下拉列表的内容同时修改下标然后修改显示的内容，显示的内容和选择的内容一致
    })
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
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
      success: function (res) {
        that.setData({
          Orientation: res.data  //把json数据赋值给变量Orientation
        })
        //获取楼房类型
        wx.request({
          url: 'http://localhost:8092/Dwelling/GetBuildingType',
          success: function (res) {
            that.setData({
              BuildingType: res.data  //把json数据赋值给变量BuildingType
            })
            //获取装修风格
            wx.request({
              url: 'http://localhost:8092/Dwelling/GetStyle',
              success: function (res) {
                that.setData({
                  Style: res.data  //把json数据赋值给变量Style
                })
                //获取房屋设施
                wx.request({
                  url: 'http://localhost:8092/Dwelling/GetFacility',
                  success: function (res) {
                    that.setData({
                      Facilityitems: res.data  //把json数据赋值给变量Facilityitems
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
  //发布房源信息
  formSubmit:function(e){
    var PublishHouse_Num=e.detail.value.PublishHouse_Num;
    var PublishHouse_Area = e.detail.value.PublishHouse_Area;
    var Orientation_ID=e.detail.value.Orientation_ID
console.log(e.detail.value);
wx.request({
  url: 'http://localhost:8092/Dwelling/AddPublishHouse',
  method: 'post',
  data: {
    PublishHouse_Num: PublishHouse_Num,
    PublishHouse_Area: PublishHouse_Area,
    Orientation_ID: Orientation_ID
  },
  success: function (res) {
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
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  },

/** */
  swiperTab: function (e) {
    var that = this;
    that.setData({
      currentTab: e.detail.current
    });
  },
  /**点击事件 */
  clickTab: function (e) { var that = this; if (this.data.currentTab === e.target.dataset.current) { return false; } else { that.setData({ currentTab: e.target.dataset.current }) } },

/**改变合租整租跳转页面 */

  swiperChange: function (e) {
    this.setData({ swiperCurrent: e.detail.current });
  },
})