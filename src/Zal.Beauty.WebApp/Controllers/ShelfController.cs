using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Wechats;
using Zal.Beauty.WebApp.Filters;

namespace Zal.Beauty.WebApp.Controllers
{
    /// <summary>
    /// 货架controller
    /// </summary>
    [CustomerOAuth]
    public class ShelfController : Controller
    {
        private readonly ICustomerManager customerManager;
        public ShelfController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
