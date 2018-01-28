using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Models.Parameters.Wechats;

namespace Zal.Beauty.Interface.IManager.Wechats
{
    /// <summary>
    /// 客户管理接口
    /// </summary>
    public interface ICustomerManager
    {
        /// <summary>
        /// 添加客户请求处理接口
        /// </summary>
        /// <returns></returns>
        Task<ReturnResult> AddCustomerAsync(CustomerParamater parameter);
    }
}
