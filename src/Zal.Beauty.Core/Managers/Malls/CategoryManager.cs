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

namespace Zal.Beauty.Core.Managers.Malls
{
    /// <summary>
    /// 商品分类mannager
    /// </summary>
    public class CategoryManager:ICategoryManager
    {
        private readonly ApplicationDbContext context;
        public CategoryManager(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<ReturnResult> AddCategory(CategoryParameter category)
        {
            var result = new ReturnResult();
            var categoryEntity = Mapper.Map<Category>(category);
            await context.Category.AddAsync(categoryEntity);
            await context.SaveChangesAsync();
            return result;
        }
        

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReturnResult> DeleteCategory(long id)
        {
            var result = new ReturnResult();
            var category = await context.Category.FirstOrDefaultAsync(c=>c.Id==id);
            category.IsDel = true;
            await context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 获取商品一级分类
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryResult>> GetFristCategory()
        {
            var categoryList = await context.Category.Where(c => c.ParentId == 0).ToListAsync();
            List<CategoryResult> categoryResultList = Mapper.Map<List<CategoryResult>>(categoryList);
            return categoryResultList;
        }


        /// <summary>
        /// 获取商品二级分类
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<List<CategoryResult>> GetSecondCategory(long parentId)
        {
            var categoryList = await context.Category.Where(c => c.ParentId == parentId).ToListAsync();
            List<CategoryResult> categoryResultList = Mapper.Map<List<CategoryResult>>(categoryList);
            return categoryResultList;
        }
    }
}
