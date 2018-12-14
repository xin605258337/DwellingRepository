// pages/homepage/homepage.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    conferencelist: [], //房源显示
    imgUrls: [
      '../../image/woniu.jpg',
      'https://public.wutongwan.org/public-20180402-Ft8Cd_qKwRig0ZZ9w1pHvsyX1VDx',
      'http://img1.gtimg.com/news/pics/hv1/117/9/2130/138505662.jpg',
      'http://img.zx123.cn/Resources/zx123cn/uploadfile/2017/0303/edaa8ff8fc71f7e8da622bc551e8020d.jpg',
      'http://static-xiaoguotu.17house.com/xgt/s/20/1462884852184aa.jpg'
    ],
    indicatorDots: true,
    vertical: false,
    autoplay: true,
    interval: 3000,
    duration: 1200,
    iconArray: [
      {
        "iconUrl": '../../image/zhengzu.png',
        "iconText": '整租',
        "url": '../mainpage/mainpage'
      },
      {
        "iconUrl": '../../image/hezu.png',
        "iconText": '合租',
        "url": '../mainpage/mainpage'
      },
      {
        "iconUrl": '../../image/fabu.png',
        "iconText": '发布房源',
        "url": '../homeissue/homeissue'
      },
    ],
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var that = this;
    //加载房源信息
    wx.request({
      url: 'http://localhost:8092/Dwelling/GetHotHouses',
      success: function (res) {
        that.setData({
          conferencelist: res.data
        })
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

  }
})