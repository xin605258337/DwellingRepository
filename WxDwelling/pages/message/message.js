// pages/message/ message.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
      suggest:[],
      complain:[]
  },
  /**点击事件 */
  swiperTab: function(e) {
    var that = this;
    that.setData({
      currentTab: e.detail.current
    });
  },
  /**点击事件 */
  clickTab: function(e) {
    var that = this;
    if (this.data.currentTab === e.target.dataset.current) {
      return false;
    } else {
      that.setData({
        currentTab: e.target.dataset.current
      })
    }
  },

  swiperChange: function(e) {
    this.setData({
      swiperCurrent: e.detail.current
    });
  },

  bindTextAreaBlur: function(e) {
    this.setData({
      Complain_Content: e.detail.value
    })
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var that=this;
    var userID = 0;
    wx.getStorage({
      key: 'userId',
      success: function(res) {
        userID = res.data
        wx.request({
          url: 'http://localhost:8092/Dwelling/GetSuggestByUserID',
          method:'GET',
          data:{
            userId: userID
          },
          success:function(res){
             that.setData({
               suggest:res.data
             })
            wx.request({
              url: 'http://localhost:8092/Dwelling/GetComplainByUserID',
              method: 'GET',
              data: {
                userId: userID
              },
              success: function (res) {
                that.setData({
                  complain: res.data
                })

              }
            })
          }
        })
      },
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

  }
})