using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zal.Beauty.WebApp.Configs
{
    /// <summary>
    /// 权限key值mvc配置
    /// </summary>
    public class PermissionKeysMvcSetting
    {
        public static readonly List<Node> Nodes = new List<Node>
        {
            //系统管理
            new Node
            {
                Title = "系统管理",
                IconClass = "linecons-cog",
                ChildNodes = new List<Node>
                {
                    new Node
                    {
                        Title = "用户管理",
                        PerMissionKeys = new List<string> { PermissionKeys.IdentityUserKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "用户信息",
                                Route = "/Identity/User/List"
                            }
                        }
                    },
                    new Node
                    {
                        Title = "角色管理",
                        PerMissionKeys = new List<string> { PermissionKeys.IdentityRoleKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "角色信息",
                                Route = "/Identity/Role/List"
                            }
                        }
                    },
                    new Node
                    {
                        Title = "权限管理",
                        PerMissionKeys = new List<string> { PermissionKeys.IdentityPermissionKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "权限信息",
                                Route = "/Identity/Permission/Index"
                            }
                        }
                    }
                }
            },
            //商城管理
            new Node
            {
                Title = "商城管理",
                IconClass = "linecons-camera",
                ChildNodes = new List<Node>
                {
                    new Node
                    {
                        Title = "分类管理",
                        PerMissionKeys = new List<string> { PermissionKeys.MallCategoryKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "分类信息",
                                Route = "/Identity/User/List"
                            }
                        }
                    },
                    new Node
                    {
                        Title = "商品管理",
                        PerMissionKeys = new List<string> { PermissionKeys.MallProductKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "商品信息",
                                Route = "/Identity/Role/List"
                            }
                        }
                    },
                    new Node
                    {
                        Title = "货架管理",
                        PerMissionKeys = new List<string> { PermissionKeys.MallShelfKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "货架信息",
                                Route = "/Identity/Permission/List"
                            }
                        }
                    },
                    new Node
                    {
                        Title = "促销管理",
                        PerMissionKeys = new List<string> { PermissionKeys.MallPromotionKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "促销信息",
                                Route = "/Identity/Permission/List"
                            }
                        }
                    },
                    new Node
                    {
                        Title = "订单管理",
                        PerMissionKeys = new List<string> { PermissionKeys.MallOrderKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "订单信息",
                                Route = "/Identity/Permission/List"
                            }
                        }
                    },
                    new Node
                    {
                        Title = "评论管理",
                        PerMissionKeys = new List<string> { PermissionKeys.MallCommontKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "评论信息",
                                Route = "/Identity/Permission/List"
                            }
                        }
                    }
                }
            },
            //微信管理
            new Node
            {
                Title = "微信管理",
                IconClass = "linecons-cog",
                ChildNodes = new List<Node>
                {
                    new Node
                    {
                        Title = "客户管理",
                        PerMissionKeys = new List<string> { PermissionKeys.WechatCustomerKeys },
                        ChildNodes = new List<Node>
                        {
                            new Node
                            {
                                Title = "客户信息",
                                Route = "/Wechat/Customer/List"
                            }
                        }
                    }
                }
            },
        };
    }

    /// <summary>
    /// 节点
    /// </summary>
    public class Node
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 路由
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        /// 图标类名
        /// </summary>
        public string IconClass { get; set; }

        /// <summary>
        /// 权限key值
        /// </summary>
        public List<string> PerMissionKeys { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<Node> ChildNodes { get; set; }
    }
}
