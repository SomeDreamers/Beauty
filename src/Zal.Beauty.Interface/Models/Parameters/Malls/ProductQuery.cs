using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Enums.Malls;

namespace Zal.Beauty.Interface.Models.Parameters.Malls
{
    /// <summary>
    /// 商品查询参数
    /// </summary>
    public class ProductQuery : Pagination
    {
        /// <summary>
        /// 品牌ID
        /// </summary>
        public long BrandId { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public EProductStatus Status { get; set; }

        /// <summary>
        /// 创建开始时间
        /// </summary>
        public DateTime CreateBegin { get; set; }

        /// <summary>
        /// 创建结束时间
        /// </summary>
        public DateTime CreateEnd { get; set; }
    }
}
