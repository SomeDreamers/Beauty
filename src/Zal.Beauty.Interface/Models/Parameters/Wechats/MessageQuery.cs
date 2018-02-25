using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Enums.Wechats;

namespace Zal.Beauty.Interface.Models.Parameters.Wechats
{
    /// <summary>
    /// 微信消息查询
    /// </summary>
    public class MessageQuery : Pagination
    {
        /// <summary>
        /// 消息源（1：接收消息；2：发送消息）
        /// </summary>
        public int MsgSource { get; set; } = 1;

        /// <summary>
        /// 消息类型
        /// </summary>
        public EMsgType Type { get; set; }

        /// <summary>
        /// 发送昵称
        /// </summary>
        public string FromUserNick { get; set; }

        /// <summary>
        /// 接收昵称
        /// </summary>
        public string ToUserNick { get; set; }

        /// <summary>
        /// 创建开始时间
        /// </summary>
        public DateTime CreateBegin { get; set; }

        /// <summary>
        /// 创建结束时间
        /// </summary>
        public DateTime CreateEnd { get; set; }
    }
}
