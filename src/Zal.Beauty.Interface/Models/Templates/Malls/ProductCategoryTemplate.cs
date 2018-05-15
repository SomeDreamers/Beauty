using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Interface.Models.Templates.Malls
{
    /// <summary>
    /// 商品分类数据模板
    /// </summary>
    public class ProductCategoryTemplate
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 一级分类Id
        /// </summary>
        public long Category1stId { get; set; }

        /// <summary>
        /// 二级分类Id
        /// </summary>
        public long Category2ndId { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public long ProductId { get; set; }
    }
}
