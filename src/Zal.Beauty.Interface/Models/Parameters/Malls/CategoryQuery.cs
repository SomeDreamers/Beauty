using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Models;

namespace Zal.Beauty.Interface.Models.Parameters.Malls
{
    /// <summary>
    /// 商品分类查询参数
    /// </summary>
    public class CategoryQuery : Pagination
    {
        /// <summary>
        /// 父级Id
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string Name { get; set; }
    }
}
