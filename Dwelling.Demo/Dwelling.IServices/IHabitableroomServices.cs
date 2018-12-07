using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    //户型接口
    public interface IHabitableroomServices
    {
         List<HabitableRoom> GetHabitableRoom();
    }
}
