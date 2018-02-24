using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Zal.Beauty.Base.Enums;

namespace Zal.Beauty.Base.Utils
{
    public class RegexUtil
    {
        private const string image = @"^.*.(?:png|jpg|bmp|gif|jpeg)$";
        /// <summary>
        /// 正则表达式判断 图片后缀
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Image(string str)
        {

            Regex regex = new Regex(image);
            if (regex.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取素材类型
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static FileType GetFileType(String postfix)
        {
            if (RegexUtil.Image(postfix))
            {
                return FileType.image;
            }
            return FileType.other;
        }

    }
}
