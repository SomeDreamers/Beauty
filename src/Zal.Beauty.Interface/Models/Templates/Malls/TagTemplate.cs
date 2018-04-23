using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Interface.Models.Templates.Malls
{
    /// <summary>
    /// 商品标签数据模板
    /// </summary>
    public class TagTemplate
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 标签名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标签样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }
    }
}
