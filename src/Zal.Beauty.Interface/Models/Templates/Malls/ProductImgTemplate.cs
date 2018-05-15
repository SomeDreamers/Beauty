using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Enums.Malls;

namespace Zal.Beauty.Interface.Models.Templates.Malls
{
    /// <summary>
    /// 商品图片数据模板
    /// </summary>
    public class ProductImgTemplate
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
        /// 图片ID
        /// </summary>
        public long ImgId { get; set; }

        /// <summary>
        /// 商品图片类型
        /// </summary>
        public EProductImgType Type { get; set; }
    }
}
