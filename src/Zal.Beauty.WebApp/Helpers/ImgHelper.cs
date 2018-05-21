using Pls.Utils.oss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Commons;

namespace Zal.Beauty.WebApp.Helpers
{
    /// <summary>
    /// 图片Helper
    /// </summary>
    public static class ImgHelper
    {
        /// <summary>
        /// 获取图片URL
        /// </summary>
        /// <param name="imgIds"></param>
        /// <param name="fileManager"></param>
        /// <returns></returns>
        public static async Task<List<KeyValuePair<long, string>>> GetImgUrlsAsync(List<long> imgIds, IFileManager fileManager)
        {
            List<KeyValuePair<long, string>> pairs = new List<KeyValuePair<long, string>>();
            var files = await fileManager.GetFilesByIdsAsync(imgIds);
            foreach (var item in files)
            {
                pairs.Add(new KeyValuePair<long, string>(item.Id, OssOptionUtil.GetOSSUrl(item.OssKey)));
            }
            return pairs;
        }
    }
}
