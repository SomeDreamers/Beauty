using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zal.Beauty.Interface.Enums.Identitys
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum EUserStatus
    {
        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        Enabled = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        [Display(Name = "禁用")]
        Disabled = 2
    }

    public static class EUserStatusExtension
    {
        public static string GetDescription(this EUserStatus type)
        {
            switch (type)
            {
                case EUserStatus.Enabled:
                    return "启用";
                case EUserStatus.Disabled:
                    return "禁用";
                default:
                    return "";
            }
        }
    }
}
