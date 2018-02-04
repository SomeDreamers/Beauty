using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Base.Models
{
    /// <summary>
    /// 集合对象（包含分页信息）
    /// </summary>
    public class EntitySet<TSource> : Pagination
    {
        /// <summary>
        /// 集合对象信息
        /// </summary>
        public List<TSource> Entities { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }
    }
}
