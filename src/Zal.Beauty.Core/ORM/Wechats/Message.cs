using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Zal.Beauty.Interface.Enums.Wechats;

namespace Zal.Beauty.Core.ORM.Wechats
{
    /// <summary>
    /// 消息
    /// </summary>
    [Table("wechat_messages")]
    public class Message
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 发送用户ID
        /// </summary>
        [Column("from_user_id")]
        public long FromUserId { get; set; }

        /// <summary>
        /// 接收用户ID
        /// </summary>
        [Column("to_user_id")]
        public long ToUserId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [Column("type")]
        public EMsgType Type { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [Column("content")]
        public string Content { get; set; }

        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。 
        /// </summary>
        [Column("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// 图片URl
        /// </summary>
        [Column("pic_url")]
        public string PicUrl { get; set; }

        /// <summary>
        /// 发送用户名
        /// </summary>
        [Column("from_user_name")]
        public string FromUserName { get; set; }

        /// <summary>
        /// 接收用户名
        /// </summary>
        [Column("to_user_name")]
        public string ToUserName { get; set; }
    }
}
