using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwelling.IServices
{
    using Dwelling.Model;
    public interface IComplainService
    {
        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="complain"></param>
        /// <returns></returns>
        int AddComplain(Complain complain);
        /// <summary>
        /// 获取投诉表信息
        /// </summary>
        /// <returns></returns>
        List<Complain> GetComplains();

        /// <summary>
        /// 根据ID获取投诉信息
        /// </summary>
        /// <param name="_Complain_ID"></param>
        /// <returns></returns>
        Complain GetComplainByID(int complainID);


        /// <summary>
        /// 修改投诉
        /// </summary>
        /// <param name="complain"></param>
        /// <returns></returns>
        int UpdateComplain(int id, string result);
        /// <summary>
        /// 根据用户ID获取信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Complain> GetComplainByUserID(int userId);


    }
}
