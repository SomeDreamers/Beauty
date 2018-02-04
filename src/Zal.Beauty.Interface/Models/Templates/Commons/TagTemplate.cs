using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Interface.Models.Templates.Commons
{
    /// <summary>
    /// 素材分类数据摹本
    /// </summary>
    public  class TagTemplate
    {
        /// <summary>
        /// 素材分类ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 素材分类名字
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public int Weight { get; set; }
    }
}
