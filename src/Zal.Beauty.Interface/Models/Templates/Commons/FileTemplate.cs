using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Interface.Models.Templates.Commons
{
    /// <summary>
    /// 素材数据模板
    /// </summary>
    public class FileTemplate
    {
        /// <summary>
        /// 素材id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 素材分类id
        /// </summary>
        public long TagId { get; set; }
        /// <summary>
        /// 素材名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 素材类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// OSS图片存储服务器key
        /// </summary>
        public String OssKey { get; set; }
        /// <summary>
        /// 素材后缀
        /// </summary>
        public String Postfix { get; set; }
        /// <summary>
        /// 素材大小
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean IsDel { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public String CreateTime { get; set; }
    }
}
