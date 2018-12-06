using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    public  interface IPublishHouseService
    {
        int AddHouse(PublishHouse House);
    }
}
