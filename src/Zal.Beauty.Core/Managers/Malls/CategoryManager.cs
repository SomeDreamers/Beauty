using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Malls;
using Zal.Beauty.Interface.IManager.Malls;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;
using System.Linq;
using Zal.Beauty.Interface.Enums.Malls;
using Zal.Beauty.Core.Common;

namespace Zal.Beauty.Core.Managers.Malls
{
    /// <summary>
    /// 商品分类mannager
    /// </summary>
    public class CategoryManager : ICategoryManager
    {
        private readonly ApplicationDbContext context;
        public CategoryManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 保存商品分类
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ReturnResult> Save(CategoryParameter parameter)
        {
            var result = new ReturnResult();
            var category = Mapper.Map<Category>(parameter);
            //验证商品分类名称
            category.Name = category.Name?.Trim();
            if (string.IsNullOrEmpty(category.Name))
                return new ReturnResult(false, "名称不能为空");
            //编辑商品分类保存
            if (category.Id > 0)
            {
                var oldCategory = await context.Categorys.FirstOrDefaultAsync(c => c.Id == category.Id);
                if (oldCategory == null || oldCategory.IsDel)
                    return new ReturnResult(false, "分类已删除");
                var tmp = await GetCategoryEntityByNameAsync(category.Name);
                if (tmp != null && tmp.Id != category.Id)
                    return new ReturnResult(false, "名称重复");
                oldCategory.Name = category.Name;
                oldCategory.Weight = category.Weight;
            }
            //新增商品分类保存
            else
            {
                var tmp = await GetCategoryEntityByNameAsync(category.Name);
                if (tmp != null)
                    return new ReturnResult(false, "名称重复");
                await context.Categorys.AddAsync(category);
            }
            await context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(long id)
        {
            //更新为已删除
            var category = await context.Categorys.FirstOrDefaultAsync(c => c.Id == id);
            category.IsDel = true;
            await context.SaveChangesAsync();
            //删除商品分类关联
            var productCategorys = await GetProductCategoryEntitysAsync(id);
            context.ProductCategorys.RemoveRange(productCategorys);
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task DeleteByIdsAsync(List<long> ids)
        {
            foreach (var id in ids)
                await DeleteByIdAsync(id);
        }

        /// <summary>
        /// 获取全部商品分类
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryResult>> GetAllCategory()
        {
            List<Category> list = await context.Categorys.Where(c => c.ParentId == 0).ToListAsync();  //获取一级分类
            List<CategoryResult> firstList = Mapper.Map<List<CategoryResult>>(list);
            foreach (CategoryResult category in firstList)
            {
                var secondList = await context.Categorys.Where(c => c.ParentId == category.Id).ToArrayAsync();//获取二级分类
                List<CategoryResult> secondListEntity = Mapper.Map<List<CategoryResult>>(secondList);
                category.listCategory = secondListEntity;
            }
            return firstList;
        }

        /// <summary>
        /// 根据Id获取二级分类
        /// </summary>
        /// <returns></returns>
        public async Task<CategoryResult> GetCategoryById(long id)
        {
            var secondList = await context.Categorys.Where(c => c.Id == id).ToArrayAsync();//获取二级分类
            CategoryResult result = Mapper.Map<CategoryResult>(secondList);
            return result;
        }

        /// <summary>
        /// 获取商品分类集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<EntitySet<CategoryResult>> GetCategorySetAsync(CategoryQuery query)
        {
            var categorySet = await GetCategoryEnititySetAsync(query);
            return Mapper.Map<EntitySet<CategoryResult>>(categorySet);
        }

        #region 内部方法
        /// <summary>
        /// 获取商品分类ORM集合
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns></returns>
        public async Task<EntitySet<Category>> GetCategoryEnititySetAsync(CategoryQuery queryParameter)
        {
            var query = context.Categorys.AsQueryable();
            if (queryParameter.ParentId > 0)
                query = query.Where(c => c.ParentId == queryParameter.ParentId);
            if (!string.IsNullOrEmpty(queryParameter.Name))
                query.Where(c => c.IsDel == false);
            //默认按时间逆序
            query.OrderBy(c => c.Id);
            var categorySet = await query.ToEntitySetAsync(queryParameter);
            return categorySet;
        }

        /// <summary>
        /// 根据名称获取分类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryEntityByNameAsync(string name)
        {
            return await context.Categorys.FirstOrDefaultAsync(c => c.Name == name);
        }

        /// <summary>
        /// 根据分类ID获取商品分类列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<List<ProductCategory>> GetProductCategoryEntitysAsync(long categoryId)
        {
            var productCategorys = await context.ProductCategorys.Where(c => c.Category1stId == categoryId || c.Category2ndId == categoryId).ToListAsync();
            return productCategorys;
        }
        #endregion
    }
}
