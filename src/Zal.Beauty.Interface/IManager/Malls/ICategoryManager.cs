using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;

namespace Zal.Beauty.Interface.IManager.Malls
{
    /// <summary>
    /// 商品分类接口
    /// </summary>
    public interface ICategoryManager
    {
        //// <summary>
        /// 保存商品分类
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<ReturnResult> Save(CategoryParameter parameter);

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(long id);

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task DeleteByIdsAsync(List<long> ids);

        /// <summary>
        /// 获取全部商品分类
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryResult>> GetAllCategory();

        /// <summary>
        /// 根据Id获取商品分类
        /// </summary>
        /// <returns></returns>
        Task<CategoryResult> GetCategoryById(long id);

        /// <summary>
        /// 获取商品分类集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<EntitySet<CategoryResult>> GetCategorySetAsync(CategoryQuery query);
    }
}
