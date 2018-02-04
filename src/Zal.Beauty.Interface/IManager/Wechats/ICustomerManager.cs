using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Models.Parameters.Wechats;
using Zal.Beauty.Interface.Models.Results.Wechats;

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

        /// <summary>
        /// 根据OpenID获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        Task<CustomerResult> GetCustomerByOpenIdAsync(string openId);

        /// <summary>
        /// 根据OpenID获取用户信息(同步方法)
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        CustomerResult GetCustomerByOpenId(string openId);
    }
}
