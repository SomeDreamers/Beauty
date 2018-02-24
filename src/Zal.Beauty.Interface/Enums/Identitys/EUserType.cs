using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zal.Beauty.Interface.Enums.Identitys
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum EUserType
    {
        /// <summary>
        /// 客户
        /// </summary>
        [Display(Name = "客户")]
        Customer = 1,
        /// <summary>
        /// 管理员
        /// </summary>
        [Display(Name = "管理员")]
        Admin = 2
    }

    public static class EUserTypeExtension
    {
        public static string GetDescription(this EUserType type)
        {
            switch (type)
            {
                case EUserType.Customer:
                    return "Customer";
                case EUserType.Admin:
                    return "Admin";
                default:
                    return "";
            }
        }
    }
}
