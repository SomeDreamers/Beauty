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
        /// 获取商品一级分类
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryResult>> GetFristCategory();

        /// <summary>
        /// 获取商品二级分类
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<CategoryResult>> GetSecondCategory(long parentId);

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

    }
}
