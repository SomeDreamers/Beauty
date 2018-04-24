using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Malls
{
    /// <summary>
    /// 商品sku
    /// </summary>
    [Table("mall_skus")]
    public class Sku
    {
        // <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [Column("product_id")]
        public long ProductId { get; set; }

        /// <summary>
        /// 图片ID
        /// </summary>
        [Column("img_id")]
        public long ImgId { get; set; }

        /// <summary>
        /// sku名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        [Column("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        [Column("purchse_price")]
        public decimal PurchsePrice { get; set; }

        /// <summary>
        /// 市场价
        /// </summary>
        [Column("market_price")]
        public decimal MarketPrice { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        [Column("sale_price")]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        [Column("barcode")]
        public string Barcode { get; set; }

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
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_del")]
        public bool IsDel { get; set; }
    }
}
