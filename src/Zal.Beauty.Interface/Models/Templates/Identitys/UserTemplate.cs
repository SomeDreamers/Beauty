using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Enums.Identitys;

namespace Zal.Beauty.Interface.Models.Templates.Identitys
{
    /// <summary>
    /// 用户数据模板
    /// </summary>
    public class UserTemplate
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public EUserType Type { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EUserStatus Status { get; set; }
    }
}
