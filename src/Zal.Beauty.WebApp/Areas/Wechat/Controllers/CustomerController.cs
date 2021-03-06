﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;
using Zal.Beauty.WebApp.Configs;

namespace Zal.Beauty.WebApp.Areas.Wechat.Controllers
{
    /// <summary>
    /// 客户Controller
    /// </summary>
    [Area("Wechat"), Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerManager customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        /// <summary>
        /// 客户列表界面
        /// </summary> 
        /// <param name="query"></param>
        /// <returns></returns>
        public IActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 客户集合ajax
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IActionResult> CusSetAjax(CustomerQuery query)
        {
            var cusSet = await customerManager.GetCusSetAsync(query);
            return Json(cusSet);
        }

        /// <summary>
        /// 客户详情
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Detail(CustomerQuery query)
        {
            return View();
        }
    }
}
