using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Zal.Beauty.Interface.Enums;
using Zal.Beauty.Interface.Enums.Identitys;

namespace Zal.Beauty.Core.ORM.Identitys
{
    /// <summary>
    /// 用户entity
    /// </summary>
    [Table("identity_users")]
    public class User
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
        [Column("true_name")]
        public string TrueName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Column("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("mail")]
        public string Mail { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Column("address")]
        public string Address { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Column("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [Column("type")]
        public EUserType Type { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Column("status")]
        public EUserStatus Status { get; set; }
    }
}
