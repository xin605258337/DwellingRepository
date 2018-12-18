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
        int AddSuggest(Suggest suggest);

        List<Suggest> GetSuggests();
    }
}
