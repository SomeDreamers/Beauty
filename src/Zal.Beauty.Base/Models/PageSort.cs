using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Enums;

namespace Zal.Beauty.Base.Models
{
    /// <summary>
    /// 排序分页
    /// </summary>
    public class PageSort
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 页面大小
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public ESortOrder SortOrder { get; set; }
    }
}
