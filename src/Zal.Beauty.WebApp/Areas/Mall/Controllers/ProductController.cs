using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Enums.Malls;
using Zal.Beauty.Interface.IManager.Commons;
using Zal.Beauty.Interface.IManager.Malls;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;
using Zal.Beauty.WebApp.Areas.Mall.ViewModels;
using Zal.Beauty.WebApp.Helpers;

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
        private readonly ISpecificationManager specificationManager;
        private readonly IFileManager fileManager;
        public ProductController(IProductManager productManager, ITagManager tagManager, IBrandManager brandManager, ISpecificationManager specificationManager, IFileManager fileManager)
        {
            this.productManager = productManager;
            this.tagManager = tagManager;
            this.brandManager = brandManager;
            this.specificationManager = specificationManager;
            this.fileManager = fileManager;
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
            //获取图片Url
            foreach (var item in proSet.Entities)
            {
                var imgPairs = await ImgHelper.GetImgUrlsAsync(item.Imgs.Select(c => c.ImgId).ToList(), fileManager);
                item.Imgs.ForEach(c => c.Url = imgPairs.FirstOrDefault(q=>q.Key == c.ImgId).Value);
                item.MainImgUrl = item.Imgs.FirstOrDefault(c => c.Type == EProductImgType.Main).Url;
            }
            return Json(proSet);
        }

        /// <summary>
        /// 新建商品界面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            var brands = await brandManager.GetAllBrandsAsync();
            var tags = await tagManager.GetAllTagsAsync();
            var specifications = await specificationManager.GetAllSpecificationsAsync();
            CreateProductModel model = new CreateProductModel
            {
                Brands = brands,
                Tags = tags,
                Specifications = specifications
            };
            return View(model);
        }

        /// <summary>
        /// 保存商品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(ProductParameter product)
        {
            var result = await productManager.SaveAsync(product);
            return Json(result);
        }
    }
}
