using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;

namespace Zal.Beauty.Core.Common
{
    /// <summary>
    /// 查询扩展类
    /// </summary>
    public static class IQueryableExtension
    {
        public static async Task<EntitySet<TSource>> ToEntitySetAsync<TSource>(this IQueryable<TSource> query, Pagination pagination)
        {
            if (pagination.Size <= 0) pagination.Size = 50;
            //设置查询的排序
            if (!string.IsNullOrEmpty(pagination.Column))
            {
                if (pagination.Sort == Base.Enums.ESortOrder.DESC)
                    query.OrderByDescending(c => pagination.Column);
                else
                    query.OrderByDescending(c => pagination.Column);
            }
            //设置查询的分页
            query.Skip(pagination.Page * pagination.Size).Take(pagination.Size);
            EntitySet<TSource> entitySet = new EntitySet<TSource>();
            entitySet.Entities = await query.ToListAsync();
            entitySet.TotalCount = await query.CountAsync();
            entitySet.TotalPages = (entitySet.TotalCount + pagination.Size - 1) / pagination.Size;
            entitySet.Page = pagination.Page;
            entitySet.Size = pagination.Size;
            entitySet.Sort = pagination.Sort;
            entitySet.Column = pagination.Column;
            return entitySet;
        }
    }
}
