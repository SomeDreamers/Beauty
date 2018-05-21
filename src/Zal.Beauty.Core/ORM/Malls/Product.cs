using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Zal.Beauty.Interface.Enums.Malls;

namespace Zal.Beauty.Core.ORM.Malls
{
    /// <summary>
    /// 商品
    /// </summary>
    [Table("mall_products")]
    public class Product
    {
        // <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        [Column("brand_id")]
        public long BrandId { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        [Column("sub_title")]
        public string SubTitle { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        [Column("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [Column("order_quantity")]
        public int OrderQuantity { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        [Column("sale_quantity")]
        public int SaleQuantity { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        [Column("status")]
        public EProductStatus Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 开始销售时间
        /// </summary>
        [Column("begin_sale_time")]
        public DateTime BeginSaleTime { get; set; }

        /// <summary>
        /// 结束销售时间
        /// </summary>
        [Column("end_sale_time")]
        public DateTime EndSaleTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_del")]
        public bool IsDel { get; set; }
    }
}
