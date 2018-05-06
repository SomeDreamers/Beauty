using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Interface.Models.Templates.Malls
{
    /// <summary>
    /// 规格值数据模板
    /// </summary>
    public class SpecificationValueTemplate
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 规格ID
        /// </summary>
        public long SpecificationId { get; set; }

        /// <summary>
        /// 规格值名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }
    }
}
