using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Enums;

namespace Zal.Beauty.Interface.Models.Templates.Wechats
{
    /// <summary>
    /// 客户数据模板
    /// </summary>
    public class CustomerTemplate
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

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
