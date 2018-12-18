// pages/Complaints/Complaints.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    currentTab: 0
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

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


  /**点击事件 */
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

  bindTextAreaBlur: function (e) {
    this.setData({
      Complain_Content: e.detail.value
    })

  }, 
  onSubmit12:function(event)
  {
    
      wx.request({
        url: 'http://localhost:8092/Dwelling/AddComplain',
        method:'post',
        data:{
          Complain_Content: this.data.Complain_Content
        },
        success:function(res)
        {
            if(res.data>0)
            {

                wx.showToast({
                  title: '添加成功',
                  duration: 2000 //提示两秒钟后关闭标题
                })
            }
        }
      })

  }
})