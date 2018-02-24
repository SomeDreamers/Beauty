using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Commons
{
    /// <summary>
    /// 素材表
    /// </summary>
    [Table("common_files")]
    public class File
    {
        /// <summary>
        /// 素材id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }
        /// <summary>
        /// 素材分类id
        /// </summary>
        [Column("tag_id")]
        public long TagId{ get; set; }
        /// <summary>
        /// 素材名称
        /// </summary>
        [Column("name")]
        public String Name { get; set; }
        /// <summary>
        /// 素材类型
        /// </summary>
        [Column("type")]
        public int Type { get; set; }
        /// <summary>
        /// OSS图片存储服务器key
        /// </summary>
        [Column("oss_key")]
        public String OssKey { get; set; }
        /// <summary>
        /// 素材后缀
        /// </summary>
        [Column("postfix")]
        public String Postfix { get; set; }
        /// <summary>
        /// 素材大小
        /// </summary>
        [Column("size")]
        public long Size { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_del")]
        public Boolean IsDel { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        [Column("create_time")]
        public String CreateTime { get; set; }
    }
}
