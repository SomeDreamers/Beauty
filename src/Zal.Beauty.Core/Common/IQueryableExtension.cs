using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
            EntitySet<TSource> entitySet = new EntitySet<TSource>();
            entitySet.Total = await query.CountAsync();
            entitySet.TotalPages = (entitySet.Total + pagination.Size - 1) / pagination.Size;
            entitySet.Start = pagination.Start;
            entitySet.Size = pagination.Size;
            entitySet.Sort = pagination.Sort;
            entitySet.Column = pagination.Column;
            //设置查询的排序
            if (!string.IsNullOrEmpty(pagination.Column))
            {
                //首字母转大写
                var columnName = Char.ToUpper(pagination.Column[0]) + pagination.Column.Substring(1, pagination.Column.Length - 1);
                if (pagination.Sort == Base.Enums.ESortOrder.DESC)
                    query = query.OrderBy(columnName, true);
                else
                    query = query.OrderBy(columnName, false);
            }
            //设置查询的分页
            entitySet.Entities = await query.Skip(pagination.Start).Take(pagination.Size).ToListAsync();
            return entitySet;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName)
        {
            return QueryableHelper<T>.OrderBy(queryable, propertyName, false);
        }
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName, bool desc)
        {
            return QueryableHelper<T>.OrderBy(queryable, propertyName, desc);
        }
        static class QueryableHelper<T>
        {
            private static Dictionary<string, LambdaExpression> cache = new Dictionary<string, LambdaExpression>();
            public static IQueryable<T> OrderBy(IQueryable<T> queryable, string propertyName, bool desc)
            {
                dynamic keySelector = GetLambdaExpression(propertyName);
                return desc ? Queryable.OrderByDescending(queryable, keySelector) : Queryable.OrderBy(queryable, keySelector);
            }
            private static LambdaExpression GetLambdaExpression(string propertyName)
            {
                if (cache.ContainsKey(propertyName)) return cache[propertyName];
                var param = Expression.Parameter(typeof(T));
                var body = Expression.Property(param, propertyName);
                var keySelector = Expression.Lambda(body, param);
                cache[propertyName] = keySelector;
                return keySelector;
            }
        }
    }
}
