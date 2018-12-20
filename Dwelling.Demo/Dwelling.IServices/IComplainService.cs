﻿using System;
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
    }
}
