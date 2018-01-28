using System;
using System.Collections.Generic;
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
        Customer = 1,
        /// <summary>
        /// 管理员
        /// </summary>
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
