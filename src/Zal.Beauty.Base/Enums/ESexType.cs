using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zal.Beauty.Base.Enums
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum ESexType
    {
        /// <summary>
        /// 男
        /// </summary>
        [Display(Name = "男")]
        Man = 1,
        /// <summary>
        /// 女
        /// </summary>
        [Display(Name = "女")]
        Woman = 2
    }
}
