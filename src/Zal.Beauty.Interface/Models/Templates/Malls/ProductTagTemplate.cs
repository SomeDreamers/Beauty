using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Interface.Models.Templates.Malls
{
    /// <summary>
    /// 商品标签数据模板
    /// </summary>
    public class ProductTagTemplate
    {
        // <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// 标签ID
        /// </summary>
        public long TagId { get; set; }
    }
}
