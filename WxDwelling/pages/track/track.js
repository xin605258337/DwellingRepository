Page({
  data: {
    servicelist: [], //服务集市列表
    trackList:[], //足迹
    trackListCount:0,
    collectList:[], //收藏
    collectListCount:0
  },
  onLoad: function () { //加载数据渲染页面
  var that=this;
  var userID=0;
    wx.getStorage({
      key: 'userId',
      success: function(res) {
        userID=res.data
        //获取收藏
        wx.request({
          url: 'http://localhost:8092/Dwelling/GetCollects',
          method: 'GET',
          data: {
            userId: userID
          },
          success:function(res){
            that.setData({
              collectList: res.data
            })
            that.setData({
              collectListCount:res.data.length
            })
            //获取足迹
            wx.request({
              url: 'http://localhost:8092/Dwelling/GetTracksByUserId',
              method:'GET',
              data:{
                userId: userID
              },
              success:function(res){
                that.setData({
                  trackList:res.data
                })
                that.setData({
                  trackListCount: res.data.length
                })
              }
            })
          }
        })
      },
    })
  },
  fetchServiceData: function () {  //获取城市列表
    let _this = this;
    wx.showToast({
      title: '加载中',
      icon: 'loading'
    })
    const perpage = 10;
    this.setData({
      page: this.data.page + 1
    })
    const page = this.data.page;
    const newlist = [];
    for (var i = (page - 1) * perpage; i < 1; i++) {
      newlist.push({
        "id": i + 1,
        "name": "上海拜特信息技术有限公司" + (i + 1),
        "city": "上海",
        "tag": "法律咨询",
        "imgurl": "http://img.mukewang.com/57fdecf80001fb0406000338-240-135.jpg"
      })
    }
    setTimeout(() => {
      _this.setData({
        servicelist: _this.data.servicelist.concat(newlist)
      })
    }, 1500)
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

})
  

 