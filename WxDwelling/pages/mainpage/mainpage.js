Page({
 
  fetchServiceData: function () {  //获取城市列表
    let _this = this;
    wx.showToast({
      title: '加载中',
      icon: 'loading'
    })

    for (var i = 4; i < i; i++) {
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
  inputSearch: function (e) {  //输入搜索文字
    this.setData({
      showsearch: e.detail.cursor > 0,
      searchtext: e.detail.value
    })
  },
  submitSearch: function () {  //提交搜索
    console.log(this.data.searchtext);
    this.fetchServiceData();
  },
  setFilterPanel: function (e) { //展开筛选面板
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
  hideFilter: function () {        //关闭筛选面板
    this.setData({
      showfilter: false,
      showfilterindex: null
    })
  },
  setSort: function (e) {          //选择排序方式
    const d = this.data;
    const dataset = e.currentTarget.dataset;
    this.setData({
      sortindex: dataset.sortindex,
      sortid: dataset.sortid
    })
    console.log('排序方式id：' + this.data.sortid);
    this.fetchConferenceData();
  },
  inputStartTime: function (e) {   //输入会议开始时间
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        starttime: e.detail.value
      })
    })
  },
  inputEndTime: function (e) {     //输入会议结束时间
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        endtime: e.detail.value
      })
    })
  },
  chooseContain: function (e) {    //选择会议室容纳人数
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        containid: e.currentTarget.dataset.id
      })
    })
    console.log('选择的会议室容量id：' + this.data.filter.containid);
  },
  region: function (e) {           //区域
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        region: e.currentTarget.dataset.id
      })
    })
    console.log('选择区域id：' + this.data.filter.region);
  },
  Prices: function (e) {           //价格
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        Prices: e.currentTarget.dataset.id
      })
    })
    console.log('价格id：' + this.data.filter.Prices);
  },
  acreage: function (e) {          //面积
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        acreage: e.currentTarget.dataset.id
      })
    })
    console.log('面积id：' + this.data.filter.acreage);
  },
  housetype: function (e) {        //户型
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        housetype: e.currentTarget.dataset.id
      })
    })
    console.log('户型id：' + this.data.filter.housetype);
  },
  Sourcetype: function (e) {       //房源类型
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        Sourcetype: e.currentTarget.dataset.id
      })
    })
    console.log('房源类型id：' + this.data.filter.Sourcetype);
  },
  Decoration: function (e) {       //装饰情况
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        Decoration: e.currentTarget.dataset.id
      })
    })
    console.log('装饰情况id：' + this.data.filter.Decoration);
  },
  orientations: function (e) {     //朝向
    this.setData({
      filter: Object.assign({}, this.data.filter, {
        orientations: e.currentTarget.dataset.id
      })
    })
    console.log('朝向id：' + this.data.filter.orientations);
  },
  setClass: function (e) {         //设置选中设备样式
    return this.data.filter.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function (e) {         //区域
    return this.data.region.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function (e) {         //价格
    return this.data.Prices.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function (e) {         //面积
    return this.data.acreage.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function (e) {         //户型
    return this.data.housetype.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function (e) {         //房源类型
    return this.data.Sourcetype.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function (e) {         //装饰情况
    return this.data.Decoration.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  setClass: function (e) {         //朝向
    return this.data.orientations.equipments.indexOf(e.currentTarget.dataset.id) > -1 ? 'active' : ''
  },
  cleanFilter: function () {       //清空筛选条件
    this.setData({
      filter: {}
    })
  },
  submitFilter: function () {      //提交筛选条件
    console.log(this.data.filter);
    this.fetchConferenceData();
  },
  goToTop: function () {           //回到顶部
    this.setData({
      scrolltop: 0
    })
  },
})