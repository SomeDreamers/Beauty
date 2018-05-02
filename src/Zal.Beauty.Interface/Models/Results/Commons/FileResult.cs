using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Models.Templates.Commons;

namespace Zal.Beauty.Interface.Models.Results.Commons
{
    public class FileResult: FileTemplate
    {
        /// <summary>
        /// OSSUrl
        /// </summary>
        public String Url { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        private int Page;
        /// <summary>
        /// 每页显示信息条数
        /// </summary>
        private int PageSize;
        /// <summary>
        /// 总页码数
        /// </summary>
        private int PageCount;
    }
}
