using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Wechats;
using Zal.Beauty.Interface.IManager.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;
using Zal.Beauty.Interface.Models.Results.Wechats;

namespace Zal.Beauty.Core.Managers.Wechats
{
    /// <summary>
    /// 客户manager
    /// </summary>
    public class CustomerManager : ICustomerManager
    {
        private readonly ApplicationDbContext context;
        public CustomerManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 添加客户请求处理接口
        /// </summary>
        /// <returns></returns>
        public async Task<ReturnResult> AddCustomerAsync(CustomerParamater parameter)
        {
            ReturnResult result = new ReturnResult();
            var customer = Mapper.Map<Customer>(parameter);
            //根据openId验证客户是否存在
            var oldCustomer = await GetCustomerEntityByOpenIdAsync(customer.Openid);
            if (oldCustomer != null)
            {
                customer.Id = oldCustomer.Id;
                context.Customers.Update(oldCustomer);
            }
            else
            {
                await context.Customers.AddAsync(customer);
            }
            await context.SaveChangesAsync();
            result.Id = customer.Id;
            return result;
        }

        /// <summary>
        /// 根据OpenID获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public async Task<CustomerResult> GetCustomerByOpenIdAsync(string openId)
        {
            var customer = await GetCustomerEntityByOpenIdAsync(openId);
            if (customer == null) return null;
            return Mapper.Map<CustomerResult>(customer);
        }

        /// <summary>
        /// 根据OpenID获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public CustomerResult GetCustomerByOpenId(string openId)
        {
            var customer = context.Customers.Where(c => c.Openid == openId).FirstOrDefault();
            if (customer == null) return null;
            return Mapper.Map<CustomerResult>(customer);
        }

        #region 内部方法
        /// <summary>
        /// 根据OpenID获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomerEntityByOpenIdAsync(string openId)
        {
            var oldCustomer = await context.Customers.Where(c => c.Openid == openId).FirstOrDefaultAsync();
            return oldCustomer;
        }
        #endregion
    }
}
