Page({
  data: {
    filterdata: {},  //筛选条件数据
    showfilter: false, //是否显示下拉筛选
    showfilterindex: null, //显示哪个筛选类目
    sortindex: 0,  //排序索引
    sortid: 1,  //排序id
    filter: { region: "0", Prices: '0', acreage: '0', housetype: 0, Sourcetype: '0', Decoration: '0', orientations: '0' },
    conferencelist: [], //房源显示
    scrolltop: null, //滚动位置
    page: 1,  //分页
    Counts: 0, //总页数
  },
  onLoad: function () {  
    var that=this;
    var reg = [{
      "id": 0,
      "title": "不限"
    }];
    var housetype=[{
      "id": 0,
      "title": "全部"
    }]
    //加载数据渲染页面
    this.fetchServiceData();
    //获取北京地区
    wx.request({
      url: 'https://apis.map.qq.com/ws/district/v1/getchildren?id=110000&key=HYPBZ-PNF3J-GRYFR-K4XZ2-3YXLV-67B5R',
      success: function (res) {
        
        for (var i = 0; i < res.data.result[0].length;i++){
          reg.push(
            {
              "id": i+1,
              "title": res.data.result[0][i].fullname
            }
          )
        }
        wx.request({
          url: 'http://localhost:8092/Dwelling/GetHabitableRoom',
          success: function (res) {
            for (var i = 0; i < res.data.length; i++) {
              housetype.push(
                {
                  "id": res.data[i].HabitableRoom_ID,
                  "title": res.data[i].HabitableRoom_Name
                }
              )
            }
            that.fetchFilterData(reg, housetype);
          }
        })
      }
    })
    //获取居室
    


  },
  fetchFilterData: function (region, housetype) { //获取筛选条件
    this.setData({
      filterdata: {
        "sort": [
          {
            "id": 1,
            "title": "最新"
          },
          
        ],
        "region": region,
        "Prices": [
          {
            "id": '0',
            "title": "不限"
          },
          {
            "id": '0,50',
            "title": "50万以下"
          },
          {
            "id": '50,80',
            "title": "50-80万"
          },
          {
            "id": '80,100',
            "title": "80-100万"
          },
          {
            "id": '100,120',
            "title": "100-120万"
          },
          {
            "id": '120,150',
            "title": "120-150万"
          },
          {
            "id": '150,200',
            "title": "150-200万"
          },
          {
            "id": '200,300',
            "title": "200-300万"
          },
          {
            "id": '300',
            "title": "300万以上"
          },
        ],
        "acreage": [
          {
            "id": '0',
            "title": "不限"
          },
          {
            "id": '0,50',
            "title": "50㎡以下"
          },
          {
            "id": '50,70',
            "title": "50-70㎡"
          },
          {
            "id": '70,90',
            "title": "70-90㎡"
          },
          {
            "id": '90,110',
            "title": "90-110㎡"
          },
          {
            "id": '110,130',
            "title": "110-130㎡"
          },
          {
            "id": '130,150',
            "title": "130-150㎡"
          },
          {
            "id": '150,200',
            "title": "150-200㎡"
          },
          {
            "id": '200,300',
            "title": "200-300㎡"
          },
          {
            "id": '300',
            "title": "300㎡以上"
          },
        ],
        "housetype": housetype,
        "Sourcetype": [
          {
            "id": '0',
            "title": "全部"
          },
          {
            "id": '住宅',
            "title": "住宅"
          },
          {
            "id": '别墅',
            "title": "别墅"
          },
          {
            "id": '商铺',
            "title": "商铺"
          },
          {
            "id": '写字楼',
            "title": "写字楼"
          },
        ],
        "Decoration": [
          {
            "id": '0',
            "title": "全部"
          },
          {
            "id": '豪装',
            "title": "豪装"
          },
          {
            "id": '简装',
            "title": "简装"
          },
          {
            "id": '毛坯',
            "title": "毛坯"
          },
          {
            "id": '精装',
            "title": "精装"
          },
          {
            "id": '中装',
            "title": "中装"
          },
        ],
        "orientations": [
          {
            "id": '0',
            "title": "全部"
          },
          {
            "id": '东南',
            "title": "东南"
          },
          {
            "id": '正东',
            "title": "正东"
          },
          {
            "id": '正西',
            "title": "正西"
          },
          {
            "id": '南北',
            "title": "南北"
          },
          {
            "id": '正南',
            "title": "正南"
          },
          {
            "id": '正北',
            "title": "正北"
          },
          {
            "id": '东西',
            "title": "东西"
          },
          {
            "id": '西南',
            "title": "西南"
          },
          {
            "id": '东北',
            "title": "东北"
          },
          {
            "id": '西北',
            "title": "西北"
          },
        ],
      }
    })
  },
  fetchServiceData: function () {  //获取城市列表
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