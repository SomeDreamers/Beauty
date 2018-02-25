using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Enums;
using Zal.Beauty.Base.Models;

namespace Zal.Beauty.Interface.Models.Parameters.Wechats
{
    /// <summary>
    /// 客户查询query
    /// </summary>
    public class CustomerQuery : Pagination
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public ESexType Sex { get; set; }

        /// <summary>
        /// 创建开始时间
        /// </summary>
        public DateTime CreateBegin { get; set; }

        /// <summary>
        /// 创建结束时间
        /// </summary>
        public DateTime CreateEnd { get; set; }
    }
}
