Page({
  data: {
    showsearch: false,   //显示搜索按钮
    searchtext: '',  //搜索文字
    filterdata: {},  //筛选条件数据
    showfilter: false, //是否显示下拉筛选
    showfilterindex: null, //显示哪个筛选类目
    sortindex: 0,  //排序索引
    sortid: 1,  //排序id
    filter: { region: "0", Prices: '0', acreage: '0', housetype: 0, Sourcetype: '0', Decoration: '0', orientations: '0' },
    sortindex: 0,  //一级分类索引
    sortid: null,  //一级分类id
    subsortindex: 0, //二级分类索引
    subsortid: null, //二级分类id
    cityindex: 0,  //一级城市索引
    cityid: null,  //一级城市id
    subcityindex: 0,  //二级城市索引
    subcityid: null, //二级城市id
    servicelist: [], //服务集市列表
    scrolltop: null, //滚动位置
    page: 0  //分页
  },
  onLoad: function () { //加载数据渲染页面
    this.fetchServiceData();
    this.fetchFilterData();
  },
  fetchFilterData: function () { //获取筛选条件
    this.setData({
      filterdata: {
        "sort": [
          {
            "id": 1,
            "title": "最新"
          },
          {
            "id": 2,
            "title": "价格"
          },
          {
            "id": 3,
            "title": "面积"
          },
        ],
        "region": [
          {
            "id": '0',
            "title": "不限"
          },
          {
            "id": '朝阳',
            "title": "朝阳"
          },
          {
            "id": '海淀',
            "title": "海淀"
          },
          {
            "id": '东城',
            "title": "东城"
          },
          {
            "id": '崇文',
            "title": "崇文"
          },
          {
            "id": '宣武',
            "title": "宣武"
          },
          {
            "id": '大兴',
            "title": "大兴"
          },
          {
            "id": '房山',
            "title": "房山"
          },
          {
            "id": '丰台',
            "title": "丰台"
          },
          {
            "id": '昌平',
            "title": "昌平"
          },
          {
            "id": '怀柔',
            "title": "怀柔"
          },
          {
            "id": '门头沟',
            "title": "门头沟"
          },
          {
            "id": '密云',
            "title": "密云"
          },
          {
            "id": '平谷',
            "title": "平谷"
          },
          {
            "id": '石景山',
            "title": "石景山"
          },
          {
            "id": '顺义',
            "title": "顺义"
          },
          {
            "id": '通州',
            "title": "通州"
          },
          {
            "id": '西城',
            "title": "西城"
          },
          {
            "id": '延庆',
            "title": "延庆"
          },
          {
            "id": '燕郊',
            "title": "燕郊"
          },
        ],
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
        "housetype": [
          {
            "id": 0,
            "title": "不限"
          },
          {
            "id": 1,
            "title": "1室"
          },
          {
            "id": 2,
            "title": "2室"
          },
          {
            "id": 3,
            "title": "3室"
          },
          {
            "id": 4,
            "title": "4室"
          },
          {
            "id": 5,
            "title": "5室以上"
          },
        ],
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
  

 