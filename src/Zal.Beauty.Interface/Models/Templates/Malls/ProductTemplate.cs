using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Enums.Malls;

namespace Zal.Beauty.Interface.Models.Templates.Malls
{
    /// <summary>
    /// 商品数据模板
    /// </summary>
    public class ProductTemplate
    {
        // <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

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
        /// 库存数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int OrderQuantity { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        public int SaleQuantity { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public EProductStatus Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 开始销售时间
        /// </summary>
        public DateTime BeginSaleTime { get; set; }

        /// <summary>
        /// 结束销售时间
        /// </summary>
        public DateTime EndSaleTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }
    }
}
