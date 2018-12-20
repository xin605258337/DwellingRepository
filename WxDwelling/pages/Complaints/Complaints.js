// pages/Complaints/Complaints.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    currentTab: 0,
    Suggest_Content:'',
    Complain_Content:''
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
    var that = this
    wx.getStorage({
      key: 'userId',
      success: function (res) {
        console.log(res.data)
        wx.request({
          url: 'http://localhost:8092/Dwelling/AddComplain',
          method: 'GET',
          data: {
            content: that.data.Complain_Content,
            userId: res.data
          },
          success: function (res) {
            console.log(res.data)
            if (res.data > 0) {
              wx.showToast({
                title: '提交成功',
                duration: 2000 //提示两秒钟后关闭标题
              })
            }
          }
        })
      },
    })
  },

  bindBlur: function (e) {
    this.setData({
      Suggest_Content: e.detail.value
    })
  }, 
  //建议
  onSubmit:function(event)
  {
    var that=this
    wx.getStorage({
      key: 'userId',
      success: function(res) {
        console.log(res.data)
        wx.request({
          url: 'http://localhost:8092/Dwelling/AddSuggest',
          method: 'GET',
          data: {
            content: that.data.Suggest_Content,
            userId:res.data
          },
          success: function (res) {
            console.log(res.data)
            if (res.data > 0) {
              wx.showToast({
                title: '提交成功',
                duration: 2000 //提示两秒钟后关闭标题
              })
            }
          }
        })
      },
    })
    

  }
})