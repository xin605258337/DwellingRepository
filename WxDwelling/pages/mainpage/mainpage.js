Page({
  data: {
    filterdata: {}, //筛选条件数据
    showfilter: false, //是否显示下拉筛选
    showfilterindex: null, //显示哪个筛选类目
    sortindex: 0, //排序索引
    sortid: 1, //排序id
    filter: {
      region: "",
      housetype: 0,
      Decoration: '0',
      orientations: '0'
    },
    conferencelist: [], //房源显示
    scrolltop: null, //滚动位置
    page: 1, //分页
    Counts: 0, //总页数
    name: ''
  },
  onLoad: function(options) {
    var that = this;

    var that = this;
    var reg = [{
      "id": 0,
      "title": "不限"
    }];
    var housetype = [{
      "id": 0,
      "title": "全部"
    }]
    var style = [{
      "id": 0,
      "title": "不限"
    }]
    var orientations = [{
      "id": 0,
      "title": "不限"
    }]
    //加载数据渲染页面
    this.fetchServiceData();
    //获取北京地区
    wx.request({
      url: 'https://apis.map.qq.com/ws/district/v1/getchildren?id=110000&key=HYPBZ-PNF3J-GRYFR-K4XZ2-3YXLV-67B5R',
      success: function(res) {
        for (var i = 0; i < res.data.result[0].length; i++) {
          reg.push({
            "id": res.data.result[0][i].id,
            "title": res.data.result[0][i].fullname
          })
        }
        //获取居室
        wx.request({
          url: 'http://localhost:8092/Dwelling/GetHabitableRoom',
          success: function(res) {
            for (var i = 0; i < res.data.length; i++) {
              housetype.push({
                "id": res.data[i].HabitableRoom_ID,
                "title": res.data[i].HabitableRoom_Name
              })
            }
            //获取装修风格
            wx.request({
              url: 'http://localhost:8092/Dwelling/GetStyle',
              success: function(res) {
                for (var i = 0; i < res.data.length; i++) {
                  style.push({
                    "id": res.data[i].Style_ID,
                    "title": res.data[i].Style_Name
                  })
                }
                //获取朝向
                wx.request({
                  url: 'http://localhost:8092/Dwelling/GetOrientation',
                  success: function(res) {
                    for (var i = 0; i < res.data.length; i++) {
                      orientations.push({
                        "id": res.data[i].Orientation_ID,
                        "title": res.data[i].Orientation_Name
                      })
                    }
                    that.fetchFilterData(reg, housetype, style, orientations);
                  }
                })
              }
            })
          }
        })
      }
    })
  },
  fetchFilterData: function(region, housetype, style, orientations) { //获取筛选条件
    this.setData({
      filterdata: {
        "sort": [{
            "id": 1,
            "title": "最新"
          },
          {
            "id": 2,
            "title": "热门"
          },
        ],
        "region": region,
        "housetype": housetype,
        "Decoration": style,
        "orientations": orientations,
      }
    })
  },
  fetchServiceData: function() { //获取城市列表

  },

  inputSearch: function(e) { //输入搜索文字
    var that = this;
    this.setData({
      showsearch: e.detail.cursor > 0,
      searchtext: e.detail.value
    })
    that.setData({
      name: e.detail.value
    })
  },

  submitSearch: function() { //提交搜索
    var that = this;
    wx.request({
      url: 'http://localhost:8092/Dwelling/GetHotHousesbyenable',
      data: {
        houseName: this.data.name
      },
      method: 'get',
      success: function(res) {
        that.setData({
          conferencelist: res.data
        })
      },
    })
  },
  setFilterPanel: function(e) { //展开筛选面板
    const d = this.data;
    const i = e.currentTarget.dataset.findex;
    if (d.showfilterindex == i) {
      this.setData({
        showfilter: false,
        showfilterindex: null
      })
    } else {
      this.setData({
        showfilter: true,
        showfilterindex: i,
      })
    }
    console.log(d.showfilterindex);
  },
  hideFilter: function() { //关闭筛选面板
    this.setData({
      showfilter: false,
      showfilterindex: null
    })
  },
  setSort: function(e) { //选择排序方式
    const d = this.data;
    const dataset = e.currentTarget.dataset;
    this.setData({
      sortindex: dataset.sortindex,
      sortid: dataset.sortid
    })
    console.log('排序方式id：' + this.data.sortid);
  },
  region: function(e) { //区域
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        region: e.currentTarget.dataset.id
      })
    })
    console.log('选择区域id：' + this.data.filter.region);
  },
  housetype: function(e) { //户型
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        housetype: e.currentTarget.dataset.id
      })
    })
    console.log('户型id：' + this.data.filter.housetype);
  },
  Sourcetype: function(e) { //房源类型
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        Sourcetype: e.currentTarget.dataset.id
      })
    })
    console.log('房源类型id：' + this.data.filter.Sourcetype);
  },
  Decoration: function(e) { //装饰情况
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        Decoration: e.currentTarget.dataset.id
      })
    })
    console.log('装饰情况id：' + this.data.filter.Decoration);
  },
  orientations: function(e) { //朝向
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        orientations: e.currentTarget.dataset.id
      })
    })
    console.log('朝向id：' + this.data.filter.orientations);
  },
  setClass: function(e) { //设置选中设备样式
    return this.data.filter.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function(e) { //区域
    return this.data.region.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function(e) { //户型
    return this.data.housetype.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function(e) { //房源类型
    return this.data.Sourcetype.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function(e) { //装饰情况
    return this.data.Decoration.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function(e) { //朝向
    return this.data.orientations.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  cleanFilter: function() { //清空筛选条件
    this.setData({
      filter: {}
    })
  },
  submitFilter: function() { //提交筛选条件
    console.log(this.data.filter);
    var that = this;
    wx.request({
      url: 'http://localhost:8092/Dwelling/GetHotHousesbyenable',
      data: {
        regionId: this.data.filter.region,
        habitableRoomId: this.data.filter.housetype,
        Orientation: this.data.filter.orientations,
        styleId: this.data.filter.Decoration,
      },
      method: 'get',
      success: function(res) {
        console.log(res.data)
        that.setData({
          conferencelist: res.data
        })
      },
    })
  },
  goToTop: function() { //回到顶部
    this.setData({
      scrolltop: 0
    })
  },
  onShow:function(){
    var that = this;
    wx.getStorage({
      key: 'text',
      success: function (res) {
        wx.request({
          url: 'http://localhost:8092/Dwelling/GetHouseByLeaseType',
          data: {
            leaseTypeName: res.data
          },
          success: function (res) {
            that.setData({
              conferencelist: res.data
            })
          }
        })
        wx.removeStorageSync('text')
      },
      fail: function (res) {
        wx.request({
          url: 'http://localhost:8092/Dwelling/GetHotHousesbyenable',
          success: function (res) {
            that.setData({
              conferencelist: res.data
            })
          }
        })
      },
    })
  }
})