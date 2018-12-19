using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dwelling.Api.Controllers
{
    using Unity;
    using Unity.Attributes;
    using Dwelling.IServices;
    using Dwelling.Model;
    using Dwelling.Common;   
    [RoutePrefix("Dwelling")]
    public class SuggestController : ApiController
    {
        [Dependency]
        public ISuggestService SuggestService { get; set;}

        /// <summary>
        /// 添加建议
        /// </summary>
        /// <param name="suggest"></param>
        /// <returns></returns>
        [Route("AddSuggest")]
        [HttpPost]
        public int AddSuggest(Suggest suggest)
        {
           return SuggestService.AddSuggest(suggest);
        }

        /// <summary>
        /// 获取建议表信息
        /// </summary>
        /// <returns></returns>
        [Route("GetSuggests")]
        [HttpGet]
        public List<Suggest> GetSuggests()
        {
            return SuggestService.GetSuggests();
        }

        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetSuggestByID")]
        [HttpGet]
        public Suggest GetSuggestByID(int id)
        {
            return SuggestService.GetSuggestByID(id);
        }

        /// <summary>
        /// 修改建议表信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_Suggest_Result"></param>
        /// <returns></returns>
        [Route("UpdateSuggest")]
        [HttpGet]
        public int UpdateSuggest(int id, string _Suggest_Result)
        {
            return SuggestService.UpdateSuggest(id, _Suggest_Result);
        }
    }
}
