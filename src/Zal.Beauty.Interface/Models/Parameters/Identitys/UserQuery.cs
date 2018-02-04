using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Enums.Identitys;

namespace Zal.Beauty.Interface.Models.Parameters.Identitys
{
    /// <summary>
    /// 用户查询参数
    /// </summary>
    public class UserQuery : Pagination
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 创建开始时间
        /// </summary>
        public DateTime CreateBegin { get; set; }

        /// <summary>
        /// 创建结束时间
        /// </summary>
        public DateTime CreateEnd { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public EUserStatus Status { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public EUserType Type { get; set; }
    }
}
