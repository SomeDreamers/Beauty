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
    /// 商品规格controller
    /// </summary>
    [Area("Mall"), Authorize]
    public class SpecificationController : Controller
    {
        private readonly ISpecificationManager specificationManager;
        public SpecificationController(ISpecificationManager specificationManager)
        {
            this.specificationManager = specificationManager;
        }

        /// <summary>
        /// 保存规格
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(SpecificationParameter parameter)
        {
            var result = await specificationManager.SaveAsync(parameter);
            return Json(result);
        }

        /// <summary>
        /// 保存规格值
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        //public async Task<IActionResult> SaveValue(SpecificationValueParameter parameter)
        //{

        //}
    }
}
