using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //建议接口
    public interface ISuggestService
    {
        /// <summary>
        /// 添加建议
        /// </summary>
        /// <param name="suggest"></param>
        /// <returns></returns>
        int AddSuggest(Suggest suggest);
        /// <summary>
        /// 获取所有建议信息
        /// </summary>
        /// <returns></returns>
        List<Suggest> GetSuggests();

        /// <summary>
        /// 根据用户ID获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Suggest> GetSuggestByUserID(int userId);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_Suggest_Result"></param>
        /// <returns></returns>
        int UpdateSuggest(int id, string _Suggest_Result);

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Suggest GetSuggestByID(int SuggestID);
       
    }
}
