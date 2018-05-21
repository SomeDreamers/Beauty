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
    /// 品牌controller
    /// </summary>
    [Area("Mall"), Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandManager brandManager;
        public BrandController(IBrandManager brandManager)
        {
            this.brandManager = brandManager;
        }

        /// <summary>
        /// 保存品牌
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(BrandParameter parameter)
        {
            var result = await brandManager.SaveAsync(parameter);
            return Json(result);
        }

        /// <summary>
        /// 删除品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(long id)
        {
            var result = await brandManager.DeleteBrandByIdAsync(id);
            return Json(result);
        }
    }
}
