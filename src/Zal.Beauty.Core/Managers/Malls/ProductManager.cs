using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.Common;
using Zal.Beauty.Core.ORM.Malls;
using Zal.Beauty.Interface.Enums.Malls;
using Zal.Beauty.Interface.IManager.Malls;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Commons;
using Zal.Beauty.Interface.Models.Results.Malls;

namespace Zal.Beauty.Core.Managers.Malls
{
    /// <summary>
    /// 商品管理manager
    /// </summary>
    public class ProductManager : IProductManager
    {
        private readonly ApplicationDbContext context;
        public ProductManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<EntitySet<ProductResult>> GetProductSetAsync(ProductQuery queryParameter)
        {
            var proSet = await GetProductORMSetAsync(queryParameter);
            var proResultSet = Mapper.Map<EntitySet<ProductResult>>(proSet);
            foreach (var item in proResultSet.Entities)
            {
                await GetProductResultExtensionAsync(item);
            }
            return proResultSet;
        }

        /// <summary>
        /// 保存商品
        /// </summary>
        /// <param name="productParameter"></param>
        /// <returns></returns>
        public async Task<ReturnResult> SaveAsync(ProductParameter productParameter)
        {
            ReturnResult result = new ReturnResult();
            //新建商品
            if (productParameter.Id <= 0)
            {
                //创建商品
                var product = Mapper.Map<Product>(productParameter);
                if (product.CreateTime == DateTime.MinValue)
                    product.CreateTime = DateTime.Now;
                product.Quantity = productParameter.Skus.Sum(c => c.Quantity);
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
                //创建商品图片
                var imgs = Mapper.Map<List<ProductImg>>(productParameter.Imgs);
                imgs.ForEach(c => c.ProductId = product.Id);
                await context.ProductImgs.AddRangeAsync(imgs);
                await context.SaveChangesAsync();
                //创建商品标签
                if (productParameter.Tags != null && productParameter.Tags.Count > 0)
                {
                    var tags = Mapper.Map<List<ProductTag>>(productParameter.Tags);
                    tags.ForEach(c => c.ProductId = product.Id);
                    await context.ProductTags.AddRangeAsync(tags);
                    await context.SaveChangesAsync();
                }
                //创建商品sku
                productParameter.Skus.ForEach(c => c.ProductId = product.Id);
                foreach (var item in productParameter.Skus)
                {
                    var sku = Mapper.Map<Sku>(item);
                    await context.Skus.AddAsync(sku);
                    await context.SaveChangesAsync();
                    //创建商品规格
                    var specifications = Mapper.Map<List<SkuSpecification>>(item.SkuSpecifications);
                    specifications.ForEach(c => c.SkuId = sku.Id);
                    await context.SkuSpecifications.AddRangeAsync(specifications);
                    await context.SaveChangesAsync();
                }
            }
            return result;
        }

        #region 内部方法
        /// <summary>
        /// 获取ProductResult对象附加信息
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public async Task GetProductResultExtensionAsync(ProductResult result)
        {
            //获取品牌信息
            var brand = await context.Brands.FirstOrDefaultAsync(c => c.Id == result.BrandId);
            result.BrandName = brand?.Name;
            //获取商品图片
            var imgs = await context.ProductImgs.Where(c => c.ProductId == result.Id).ToListAsync();
            result.Imgs = Mapper.Map<List<ProductImgResult>>(imgs);
        }

        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns></returns>
        public async Task<EntitySet<Product>> GetProductORMSetAsync(ProductQuery queryParameter)
        {
            var query = context.Products.AsQueryable();
            if (queryParameter.BrandId > 0)
                query = query.Where(c => c.BrandId == queryParameter.BrandId);
            if (!string.IsNullOrEmpty(queryParameter.Name))
                query = query.Where(c => c.Name.Contains(queryParameter.Name));
            if (!string.IsNullOrEmpty(queryParameter.SubTitle))
                query = query.Where(c => c.SubTitle.Contains(queryParameter.SubTitle));
            if (Enum.IsDefined(typeof(EProductStatus), queryParameter.Status))
                query = query.Where(c => c.Status == queryParameter.Status);
            if (queryParameter.CreateBegin != DateTime.MinValue)
                query = query.Where(c => c.CreateTime >= queryParameter.CreateBegin);
            if (queryParameter.CreateEnd != DateTime.MinValue)
                query = query.Where(c => c.CreateTime <= queryParameter.CreateEnd);
            query.Where(c => c.IsDel == false);
            //默认按时间逆序
            query.OrderByDescending(c => c.CreateTime);
            var proSet = await query.ToEntitySetAsync(queryParameter);
            return proSet;
        }
        #endregion
    }
}
