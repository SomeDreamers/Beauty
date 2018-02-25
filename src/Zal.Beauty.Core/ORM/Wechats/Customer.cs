using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Zal.Beauty.Base.Enums;

namespace Zal.Beauty.Core.ORM.Wechats
{
    /// <summary>
    /// 客户
    /// </summary>
    [Table("wechat_customers")]
    public class Customer
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Column("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [Column("country")]
        public string Country { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [Column("province")]
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [Column("city")]
        public string City { get; set; }

        /// <summary>
        /// 头像URL
        /// </summary>
        [Column("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// 微信openId
        /// </summary>
        [Column("openid")]
        public string Openid { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Column("sex")]
        public ESexType Sex { get; set; }

        /// <summary>
        /// 微信unionId
        /// </summary>
        [Column("unionid")]
        public string Unionid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
    }
}
