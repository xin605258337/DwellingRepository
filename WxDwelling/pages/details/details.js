Page({
  data: {
    conferencelist: [],
    spaceimgs: [],
    currentIndex: 1
  },
  onLoad: function (options) {
    const newlist = [];
    var that = this;
    wx.request({
      url: 'http://localhost:8092/Dwelling/GetHouseByID?houseId=' + options.ID,
      method: 'GET',
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        console.log(res.data.House_Name);
        newlist.push({
          
          "ResidName": res.data.House_Name,//房源名称
          "IndoorUrl": "../../image/" + res.data.House_ImgUrl,//图片显示
          
        })
        that.setData({
          conferencelist: newlist
        })
      }
    })
  },
  })

