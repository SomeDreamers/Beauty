using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Malls;
using Zal.Beauty.Interface.Models.Parameters.Malls;

namespace Zal.Beauty.WebApp.Areas.Mall.Controllers
{
    /// <summary>
    /// 商品分类controller
    /// </summary>
    [Area("Mall"), Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        /// <summary>
        /// 商品分类界面
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IActionResult List(CategoryQuery query)
        {
            return View();
        }

        /// <summary>
        /// 商品分类Ajax加载数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IActionResult> CategorySetAjax(CategoryQuery query)
        {
            var categories = await categoryManager.GetCategorySetAsync(query);
            return View(categories);
        }

        /// <summary>
        /// 保存商品分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(CategoryParameter category)
        {
            var result = await categoryManager.Save(category);
            return Json(result);
        }
    }
}
