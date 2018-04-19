using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Zal.Beauty.Interface.Enums.Malls;

namespace Zal.Beauty.Core.ORM.Malls
{
    /// <summary>
    /// 商品图片
    /// </summary>
    [Table("mall_product_imgs")]
    public class ProductImg
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
        /// 商品图片类型
        /// </summary>
        [Column("type")]
        public EProductImgType Type { get; set; }
    }
}
