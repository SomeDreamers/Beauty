using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Enums.Malls;
using Zal.Beauty.Interface.IManager.Malls;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;
using Zal.Beauty.WebApp.Areas.Mall.ViewModels;

namespace Zal.Beauty.WebApp.Areas.Mall.Controllers
{
    /// <summary>
    /// 商品controller
    /// </summary>
    [Area("Mall"), Authorize]
    public class ProductController : Controller
    {
        private readonly IProductManager productManager;
        private readonly ITagManager tagManager;
        private readonly IBrandManager brandManager;
        public ProductController(IProductManager productManager, ITagManager tagManager, IBrandManager brandManager)
        {
            this.productManager = productManager;
            this.tagManager = tagManager;
            this.brandManager = brandManager;
        }

        /// <summary>
        /// 商品列表界面
        /// </summary> 
        /// <param name="query"></param>
        /// <returns></returns>
        public IActionResult List(EProductStatus Status = EProductStatus.New)
        {
            ViewData["Status"] = Status;
            return View();
        }

        /// <summary>
        /// 商品集合ajax
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IActionResult> ProSetAjax(ProductQuery query)
        {
            var proSet = await productManager.GetProductSetAsync(query);
            return Json(proSet);
        }

        /// <summary>
        /// 新建商品
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            var brands = await brandManager.GetAllBrandsAsync();
            var tags = await tagManager.GetAllTagsAsync();
            CreateProductModel model = new CreateProductModel
            {
                Brands = brands,
                Tags = tags
            };
            return View(model);
        }
    }
}
