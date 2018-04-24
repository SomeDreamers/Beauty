using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zal.Beauty.Interface.Enums.Wechats
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum EMsgType
    {
        /// <summary>
        /// 文本
        /// </summary>
        [Display(Name = "文本")]
        Text = 1,
        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name = "图片")]
        Image = 2
    }
}
