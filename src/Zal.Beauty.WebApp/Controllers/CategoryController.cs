using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Malls;

namespace Zal.Beauty.WebApp.Controllers
{
    /// <summary>
    /// 微信商品分类
    /// </summary>
    public class CategoryController:Controller
    {
            public readonly ICategoryManager categoryManager;
            public CategoryController(ICategoryManager categoryManager)
            {
                this.categoryManager = categoryManager;
            }

            /// <summary>
            /// 微信商品分类主页
            /// </summary>
            /// <returns></returns>
            public async Task<IActionResult> Index()
            {
            //var model = await categoryManager.GetCategoryAllInfosAsync();
            //return View(model);
            return null;
            }

        }
}
