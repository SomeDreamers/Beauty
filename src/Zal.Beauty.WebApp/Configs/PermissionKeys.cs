using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Zal.Beauty.WebApp.Configs
{
    /// <summary>
    /// 权限keys
    /// </summary>
    public class PermissionKeys
    {
        #region 系统管理
        /// <summary>
        /// 用户管理权限key值
        /// </summary>
        public const string IdentityUserKeys = "identity.user.manager";

        /// <summary>
        /// 角色管理权限key值
        /// </summary>
        public const string IdentityRoleKeys = "identity.role.manager";

        /// <summary>
        /// 权限管理权限key值
        /// </summary>
        public const string IdentityPermissionKeys = "identity.permission.manager";
        #endregion

        #region 商城管理
        /// <summary>
        /// 分类管理权限key值
        /// </summary>
        public const string MallCategoryKeys = "mall.category.manager";

        /// <summary>
        /// 商品管理权限key值
        /// </summary>
        public const string MallProductKeys = "mall.product.manager";

        /// <summary>
        /// 货架管理权限key值
        /// </summary>
        public const string MallShelfKeys = "mall.shelf.manager";

        /// <summary>
        /// 促销管理权限key值
        /// </summary>
        public const string MallPromotionKeys = "mall.promotion.manager";

        /// <summary>
        /// 订单管理权限key值
        /// </summary>
        public const string MallOrderKeys = "mall.order.manager";

        /// <summary>
        /// 评论管理权限key值
        /// </summary>
        public const string MallCommontKeys = "mall.commont.manager";
        #endregion

        #region 微信管理
        /// <summary>
        /// 客户管理权限key值
        /// </summary>
        public const string WechatCustomerKeys = "whchat.customer.manager";
        #endregion

        public static string GetKeyDescription(string key)
        {
            switch (key)
            {
                case IdentityUserKeys: return "用户管理";
                case IdentityRoleKeys: return "角色管理";
                case IdentityPermissionKeys: return "权限管理";
                case MallCategoryKeys: return "分类管理";
                case MallProductKeys: return "商品管理";
                case MallShelfKeys: return "货架管理";
                case MallPromotionKeys: return "促销管理";
                case MallOrderKeys: return "订单管理";
                case MallCommontKeys: return "评论管理";
                case WechatCustomerKeys: return "客户管理";
                default:
                    return "";
            }
        }
    }
}
