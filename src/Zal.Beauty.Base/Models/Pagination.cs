using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Enums;

namespace Zal.Beauty.Base.Models
{
    /// <summary>
    /// 分页
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 起始下标
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public ESortOrder Sort { get; set; }

        /// <summary>
        /// 排序列名
        /// </summary>
        public string Column { get; set; }
    }
}
