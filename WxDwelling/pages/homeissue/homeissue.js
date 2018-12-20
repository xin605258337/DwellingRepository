  // pages/homeissue/homeissue.js
Page({
  /**
   * 页面的初始数据
   */
  data: {
    roomType: [],
      imgUrls: [
        'https://public.wutongwan.org/public-20180402-Ft8Cd_qKwRig0ZZ9w1pHvsyX1VDx',
        'http://img1.gtimg.com/news/pics/hv1/117/9/2130/138505662.jpg',                  'http://img.zx123.cn/Resources/zx123cn/uploadfile/2017/0303/edaa8ff8fc71f7e8da622bc551e8020d.jpg',
        'http://static-xiaoguotu.17house.com/xgt/s/20/1462884852184aa.jpg'
      ],
      indicatorDots: true,
      vertical: false,
      autoplay: true,
      interval: 2000,
      duration: 1200, 
    roomType: [],
    hx_index: 0
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
    var that=this;
    //获取居室
    wx.request({
      url: 'http://localhost:8092/Dwelling/GetHabitableRoom',
      success: function (res) {
        that.setData({
          roomType: res.data  //把json数据赋值给变量pic_array_hx
        }) 
      }
    })
  },
  //跳转下一页
  applySubmit:function(){
    var param=this.data;
    wx.navigateTo({
      url: '../homeissueone/homeissueone?owner=' + param.owner + '&tel=' + param.tel + '&area=' + param.area + '&price=' + param.price + '&roomTypeId=' + param.roomTypeId + '&description=' + param.description
    })   
    console.log(param.owner) 
  },

  formSubmit(e) {
    this.setData({
      owner : e.detail.value["PublishHouse_Owner"],
      tel : e.detail.value["PublishHouse_OwnerTel"],
      price : e.detail.value["PublishHouse_RentMoney"],
      roomTypeId : e.detail.value["HabitableRoom_ID"],
      description : e.detail.value["PublishHouse_Description"]
    })
    var param = this.data;
    wx.navigateTo({
      url: '../homeissueone/homeissueone?owner=' + param.owner + '&tel=' + param.tel +'&price=' + param.price + '&roomTypeId=' + param.roomTypeId + '&description=' + param.description
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
  
})