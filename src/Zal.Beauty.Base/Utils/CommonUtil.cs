using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Zal.Beauty.Base.Utils
{
    public class CommonUtil
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>返回加密后的字符串信息</returns>
        public static string MD5(string str)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "").ToLower();
            }
        }
    }
}
