using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    public interface IFacilityService
    {
        List<Facility> GetFacility();
    }
}
