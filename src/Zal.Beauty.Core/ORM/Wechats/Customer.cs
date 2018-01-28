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
        public long Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 头像URL
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 微信openId
        /// </summary>
        public string Openid { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public ESexType Sex { get; set; }

        /// <summary>
        /// 微信unionId
        /// </summary>
        public string Unionid { get; set; }
    }
}
