using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Malls;
using Zal.Beauty.Interface.IManager.Malls;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;

namespace Zal.Beauty.Core.Managers.Malls
{
    /// <summary>
    /// 品牌manager
    /// </summary>
    public class BrandManager : IBrandManager
    {
        private readonly ApplicationDbContext context;
        public BrandManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 保存品牌
        /// </summary>
        /// <returns></returns>
        public async Task<ReturnResult> SaveAsync(BrandParameter parameter)
        {
            var result = new ReturnResult();
            var brand = Mapper.Map<Brand>(parameter);
            //验证品牌名是否为空
            brand.Name = brand.Name?.Trim();
            if (string.IsNullOrEmpty(brand.Name))
            {
                result.IsSuccess = false;
                result.Message = "品牌名称不能为空";
                return result;
            }
            //新增品牌
            if (brand.Id <= 0)
            {
                //验证品牌名是否重复
                var tmpBrand = await context.Brands.FirstOrDefaultAsync(c => c.Name == brand.Name);
                if(tmpBrand != null)
                {
                    result.IsSuccess = false;
                    result.Message = "品牌名称不能重复";
                    return result;
                }
                //设置时间
                if (brand.CreateTime == DateTime.MinValue)
                    brand.CreateTime = DateTime.Now;
                //创建品牌
                await context.Brands.AddAsync(brand);
                await context.SaveChangesAsync();
                result.Id = brand.Id;
            }
            //编辑品牌
            else
            {
                //验证品牌是否存在
                var oldBrand = await context.Brands.FirstOrDefaultAsync(c => c.Id == brand.Id);
                if(oldBrand == null || oldBrand.IsDel)
                {
                    result.IsSuccess = false;
                    result.Message = "该品牌已被删除";
                    return result;
                }
                //验证品牌名是否重复
                var tmpBrand = await context.Brands.FirstOrDefaultAsync(c => c.Name == brand.Name && !c.IsDel);
                if (tmpBrand != null && tmpBrand.Id != tmpBrand.Id)
                {
                    result.IsSuccess = false;
                    result.Message = "品牌名称不能重复";
                    return result;
                }
                //更新品牌
                oldBrand.Name = brand.Name;
                context.Brands.Update(oldBrand);
                await context.SaveChangesAsync();
            }
            return result;
        }

        /// <summary>
        /// 获取所有品牌
        /// </summary>
        /// <returns></returns>
        public async Task<List<BrandResult>> GetAllBrandsAsync()
        {
            var brands = await context.Brands.Where(c=>c.IsDel == false).ToListAsync();
            return Mapper.Map<List<BrandResult>>(brands);
        }

        /// <summary>
        /// 通过ID删除品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReturnResult> DeleteBrandByIdAsync(long id)
        {
            ReturnResult result = new ReturnResult();
            var brand = await context.Brands.FirstOrDefaultAsync(c => c.Id == id);
            if(brand == null || brand.IsDel)
            {
                result.IsSuccess = false;
                result.Message = "该品牌已被删除！";
                return result;
            }
            var count = await context.Products.Where(c => c.BrandId == id).CountAsync();
            if(count > 0)
            {
                result.IsSuccess = false;
                result.Message = "其它商品在使用该品牌，无法删除！";
                return result;
            }
            //更新品牌删除状态
            brand.IsDel = true;
            await context.SaveChangesAsync();
            return result;
        }
    }
}
