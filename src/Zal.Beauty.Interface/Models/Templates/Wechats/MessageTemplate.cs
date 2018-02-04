using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Enums.Wechats;

namespace Zal.Beauty.Interface.Models.Templates.Wechats
{
    /// <summary>
    /// 消息数据模板
    /// </summary>
    public class MessageTemplate
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 发送用户ID
        /// </summary>
        public long FromUserId { get; set; }

        /// <summary>
        /// 接收用户ID
        /// </summary>
        public long ToUserId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public EMsgType Type { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。 
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 图片URl
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 发送用户名
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 接收用户名
        /// </summary>
        public string ToUserName { get; set; }
    }
}
