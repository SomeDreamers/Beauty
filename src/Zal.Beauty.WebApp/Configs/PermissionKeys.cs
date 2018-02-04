using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        [Description("用户管理")]
        public const string IdentityUserKeys = "identity.user.manager";

        /// <summary>
        /// 角色管理权限key值
        /// </summary>
        [Description("角色管理")]
        public const string IdentityRoleKeys = "identity.role.manager";

        /// <summary>
        /// 权限管理权限key值
        /// </summary>
        [Description("权限管理")]
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
    }
}
