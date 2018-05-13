using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Interface.Models.Templates.Malls
{
    /// <summary>
    /// 商品分类数据模板
    /// </summary>
    public class CategoryTemplate
    {
        /// <summary>
        /// 商品分类Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 父级分类Id
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// 权重
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean IsDel { get; set; }
    }
}
