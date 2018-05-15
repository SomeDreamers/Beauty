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
            await context.Categorys.AddAsync(categoryEntity);
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
            var category = await context.Categorys.FirstOrDefaultAsync(c=>c.Id==id);
            category.IsDel = true;
            await context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 获取全部商品分类
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryResult>> GetAllCategory()
        {
            List<Category> list =await context.Categorys.Where(c => c.ParentId == 0).ToListAsync();  //获取一级分类
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
    }
}
