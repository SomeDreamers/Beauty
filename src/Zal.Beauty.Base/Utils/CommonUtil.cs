using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
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

        /// <summary>
        /// 将实体对象转换为Json对象，生成字符串
        /// </summary>
        /// <param name="item">实体对象</param>
        /// <returns></returns>
        public static string SerializeObject(object item)
        {
            try
            {
                return JsonConvert.SerializeObject(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 将Json串对象解析成固定的对象信息
        /// </summary>
        /// <typeparam name="T">需要得到解析后对象的实体类型</typeparam>
        /// <param name="jsonStr">json串</param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string jsonStr)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
