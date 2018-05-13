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
    /// 规格manager
    /// </summary>
    public class SpecificationManager : ISpecificationManager
    {
        private readonly ApplicationDbContext context;
        public SpecificationManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        #region 规格管理
        /// <summary>
        /// 保存规格
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ReturnResult> SaveAsync(SpecificationParameter parameter)
        {
            ReturnResult result = new ReturnResult();
            var specification = Mapper.Map<Specification>(parameter);
            specification.Name = specification.Name?.Trim();
            //验证规格名称
            if (string.IsNullOrEmpty(specification.Name))
            {
                result.IsSuccess = false;
                result.Message = "规格名称不能为空";
                return result;
            }
            //新增规格
            if (specification.Id <= 0)
            {
                var tmpSpecification = await context.Specifications.FirstOrDefaultAsync(c => c.Name == specification.Name && c.IsDel == false);
                if (tmpSpecification != null)
                {
                    result.IsSuccess = false;
                    result.Message = "规格名称重复";
                    return result;
                }
                //设置创建时间
                if (specification.CreateTime == DateTime.MinValue)
                    specification.CreateTime = DateTime.Now;
                //创建规格
                await context.Specifications.AddAsync(specification);
                await context.SaveChangesAsync();
                result.Id = specification.Id;
            }
            //更新规格
            else
            {
                var oldSpecification = await context.Specifications.FirstOrDefaultAsync(c => c.Id == specification.Id);
                if (oldSpecification == null || oldSpecification.IsDel)
                {
                    result.IsSuccess = false;
                    result.Message = "规格已被删除";
                    return result;
                }
                var tmpSpecification = await context.Specifications.FirstOrDefaultAsync(c => c.Name == specification.Name && c.IsDel == false);
                if (tmpSpecification != null && tmpSpecification.Id != oldSpecification.Id)
                {
                    result.IsSuccess = false;
                    result.Message = "规格名称重复";
                    return result;
                }
                //更新规格名称
                oldSpecification.Name = specification.Name;
                await context.SaveChangesAsync();
            }
            return result;
        }

        /// <summary>
        /// 获取所有规格
        /// </summary>
        /// <returns></returns>
        public async Task<List<SpecificationResult>> GetAllSpecificationsAsync()
        {
            var specifications = await context.Specifications.Where(c => c.IsDel == false).ToListAsync();
            var results = Mapper.Map<List<SpecificationResult>>(specifications);
            foreach (var item in results)
            {
                item.Values = await GetValuesBySpecificationIdAsync(item.Id);
            }
            return results;
        }
        #endregion

        #region 规格值管理
        /// <summary>
        /// 根据规格ID获取规格值
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        public async Task<List<SpecificationValueResult>> GetValuesBySpecificationIdAsync(long specificationId)
        {
            var values = await context.SpecificationValues.Where(c => c.SpecificationId == specificationId).ToListAsync();
            return Mapper.Map<List<SpecificationValueResult>>(values);
        }

        /// <summary>
        /// 保存规格值
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ReturnResult> SaveValueAsync(SpecificationValueParameter parameter)
        {
            ReturnResult result = new ReturnResult();
            var value = Mapper.Map<SpecificationValue>(parameter);
            value.Name = value.Name?.Trim();
            //验证规格值名称
            if (string.IsNullOrEmpty(value.Name))
            {
                result.IsSuccess = false;
                result.Message = "规格值名称不能为空";
                return result;
            }
            //新增规格值
            if (value.Id <= 0)
            {
                //验证规格ID
                if(value.SpecificationId <= 0)
                {
                    result.IsSuccess = false;
                    result.Message = "规格不存在";
                    return result;
                }
                //验证规格值名称
                var tmpValue = await context.SpecificationValues.FirstOrDefaultAsync(c => c.SpecificationId == value.SpecificationId && c.Name == value.Name && c.IsDel == false);
                if (tmpValue != null)
                {
                    result.IsSuccess = false;
                    result.Message = "规格值名称重复";
                    return result;
                }
                //创建规格值
                await context.SpecificationValues.AddAsync(value);
                await context.SaveChangesAsync();
                result.Id = value.Id;
            }
            //更新规格值
            else
            {
                var oldSpecification = await context.SpecificationValues.FirstOrDefaultAsync(c => c.Id == value.Id);
                if (oldSpecification == null || oldSpecification.IsDel)
                {
                    result.IsSuccess = false;
                    result.Message = "规格值已被删除";
                    return result;
                }
                var tmpSpecification = await context.SpecificationValues.FirstOrDefaultAsync(c => c.SpecificationId == value.SpecificationId && c.Name == value.Name && c.IsDel == false);
                if (tmpSpecification != null && tmpSpecification.Id != oldSpecification.Id)
                {
                    result.IsSuccess = false;
                    result.Message = "规格值名称重复";
                    return result;
                }
                //更新规格名称
                oldSpecification.Name = value.Name;
                await context.SaveChangesAsync();
            }
            return result;
        }
        #endregion
    }
}
