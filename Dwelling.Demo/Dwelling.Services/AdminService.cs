using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.Services
{
    using System.Configuration;
    //理员Service
    public class AdminService
    {
        //连接数据库字符串
        private static readonly string connStr= ConfigurationManager.ConnectionStrings["DwellingDB"].ConnectionString;
    }
}
