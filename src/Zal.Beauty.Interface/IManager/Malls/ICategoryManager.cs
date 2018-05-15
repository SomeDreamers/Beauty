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
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<ReturnResult> AddCategory(CategoryParameter category);


        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <returns></returns>
        Task<ReturnResult> DeleteCategory(long id);

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

    }
}
