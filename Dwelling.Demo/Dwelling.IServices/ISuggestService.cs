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

        List<Suggest> GetSuggests();

        Suggest GetSuggestByID(int id);

        int UpdateSuggest(int id, string _Suggest_Result);
    }
}
